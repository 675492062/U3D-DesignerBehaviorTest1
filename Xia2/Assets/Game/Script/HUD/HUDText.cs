/****************************************************************************** 
 * 
 * Maintaince Logs: 
 * 2014-10-30   WP      Initial version
 * 
 * *****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// HUD text creates temporary on-screen text entries that are perfect for damage, effects, and messages.
/// </summary>

public class HUDText : MonoBehaviour
{
    protected class Entry
    {
        public Vector3 enablePos = Vector3.zero; //local postion by this label enable
        public float time;			// Timestamp of when this entry was added
        public float stay = 0f;		// How long the text will appear to stay stationary on the screen
        public float offsetX = 0f;
        public float offsetY = 0f;	// How far the object has moved based on time
        public float val = 0f;		// Optional value (used for damage)
        public UILabel label;		// Label on the game object

        public float movementStart { get { return time + stay; } }
    }

    /// <summary>
    /// Sorting comparison function.
    /// </summary>

    static int Comparison(Entry a, Entry b)
    {
        if (a.movementStart < b.movementStart) return -1;
        if (a.movementStart > b.movementStart) return 1;
        return 0;
    }

    /// <summary>
    /// Font that will be used to create labels.
    /// </summary>

    public UILabel prbLabel;

    public AnimationCurve offsetCurveX = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(3f, 40f) });

    /// <summary>
    /// Curve used to move entries with time.
    /// </summary>

    public AnimationCurve offsetCurveY = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(3f, 40f) });

    /// <summary>
    /// Curve used to fade out entries with time.
    /// </summary>

    public AnimationCurve alphaCurve = new AnimationCurve(new Keyframe[] { new Keyframe(1f, 1f), new Keyframe(3f, 0f) });

    /// <summary>
    /// Curve used to scale the entries.
    /// </summary>

    public AnimationCurve scaleCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f), new Keyframe(0.25f, 1f) });

    float mEndTime = 0;
    float endTime
    {
        get
        {
            if (mEndTime == 0)
            {

                Keyframe[] xOffsets = offsetCurveX.keys;
                Keyframe[] yOffsets = offsetCurveY.keys;
                Keyframe[] alphas = alphaCurve.keys;
                Keyframe[] scales = scaleCurve.keys;

                float xOffsetEnd = xOffsets[xOffsets.Length - 1].time;
                float yOffsetEnd = yOffsets[yOffsets.Length - 1].time;
                float alphaEnd = alphas[alphas.Length - 1].time;
                float scalesEnd = scales[scales.Length - 1].time;

                mEndTime = Mathf.Max(new float[] { xOffsetEnd, yOffsetEnd, alphaEnd, scalesEnd });
            }
            return mEndTime;
        }
    }

    List<Entry> mList = new List<Entry>();
    List<Entry> mUnused = new List<Entry>();

    int counter = 0;

    /// <summary>
    /// Create a new entry, reusing an old entry if necessary.
    /// </summary>

    Entry Create()
    {
        // See if an unused entry can be reused
        if (mUnused.Count > 0)
        {
            Entry ent = mUnused[mUnused.Count - 1];
            mUnused.RemoveAt(mUnused.Count - 1);
            ent.time = Time.realtimeSinceStartup;
            ent.label.depth = NGUITools.CalculateNextDepth(gameObject);
            NGUITools.SetActive(ent.label.gameObject, true);
            ent.label.enabled = true;
            ent.offsetY = 0f;
            mList.Add(ent);
            return ent;
        }

        // New entry
        Entry ne = new Entry();
        ne.time = Time.realtimeSinceStartup;
        ne.label = KMTools.AddChild<UILabel>(gameObject, prbLabel);
        ne.label.enabled = true;

        // Make it small so that it's invisible to start with
        //ne.label.cachedTransform.localScale = new Vector3(0.001f, 0.001f, 0.001f);
        mList.Add(ne);
        ++counter;
        return ne;
    }

    /// <summary>
    /// Delete the specified entry, adding it to the unused list.
    /// </summary>

    void Delete(Entry ent)
    {
        mList.Remove(ent);
        mUnused.Add(ent);
        NGUITools.SetActive(ent.label.gameObject, false);
    }

    /// <summary>
    /// Add a new scrolling text entry.
    /// </summary>

    public void Add(object obj, Color c, float stayDuration)
    {
        if (!enabled) return;

        float val = 0f;

        if (obj is float)
        {
            val = (float)obj;
        }
        else if (obj is int)
        {
            val = (int)obj;
        }

        if (val == 0f) return;

        // Create a new entry
        Entry ne = Create();
        ne.stay = stayDuration;
        ne.label.color = c;
        ne.val = val;

        ne.label.text = obj.ToString();
        // Sort the list
        mList.Sort(Comparison);
    }

    public void Add(string text, Vector3 worldPos)
    {
        if (!enabled) return;

        Entry ne = Create();

        Vector3 pos = HUDRoot.instance.GamePosConvertUIPos(worldPos);
        ne.label.transform.position = pos;
        ne.enablePos = ne.label.transform.localPosition;

		//TODO:
        ne.label.text = text ;
		//ne.label.text = Random.Range( 30, 129).ToString();

        mList.Sort(Comparison);
    }

    public void Add(string text)
    {
        if (!enabled) return;

        Entry ne = Create();

		//TODO:
		ne.label.text = text;
		//ne.label.text = Random.Range(8,29).ToString();

        mList.Sort(Comparison);
    }

    /// <summary>
    /// Disable all labels when this script gets disabled.
    /// </summary>

    void OnDisable()
    {
        for (int i = mList.Count; i > 0; )
        {
            Entry ent = mList[--i];
            if (ent.label != null) ent.label.enabled = false;
            else mList.RemoveAt(i);
        }
    }

    /// <summary>
    /// Update the position of all labels, as well as update their size and alpha.
    /// </summary>

    void Update()
    {
        float time = Time.realtimeSinceStartup;

        // Adjust alpha and delete old entries
        for (int i = mList.Count; i > 0; )
        {
            Entry ent = mList[--i];
            float currentTime = time - ent.movementStart;
            ent.offsetX = offsetCurveX.Evaluate(currentTime);
            ent.offsetY = offsetCurveY.Evaluate(currentTime);
            ent.label.alpha = alphaCurve.Evaluate(currentTime);

            // Make the label scale in
            float s = scaleCurve.Evaluate(time - ent.time);
            if (s < 0.001f) s = 0.001f;
            ent.label.cachedTransform.localScale = new Vector3(s, s, s);

            Vector3 pos = ent.enablePos;
            pos.y += ent.offsetY;
            pos.x += ent.offsetX;
            ent.label.cachedTransform.localPosition = pos;

            // Delete the entry when needed
            if (currentTime > endTime) Delete(ent);
            else ent.label.enabled = true;
        }

       
    }
}
