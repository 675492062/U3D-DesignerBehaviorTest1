
using UnityEngine;

/// <summary>
/// Attaching this script to an object will make it visibly follow another object, even if the two are using different cameras to draw them.
/// </summary>

public class UIFollowTarget : MonoBehaviour
{
    /// <summary>
    /// 3D target that this object will be positioned above.
    /// </summary>

    public Transform target;

    /// <summary>
    /// Game camera to use.
    /// </summary>

    Camera gameCamera;

    /// <summary>
    /// UI camera to use.
    /// </summary>

    Camera uiCamera;

    /// <summary>
    /// Whether the children will be disabled when this object is no longer visible.
    /// </summary>

    public bool disableIfInvisible = true;

    Transform mTrans;
    bool mIsVisible = false;

    /// <summary>
    /// 记录最后一帧跟随位置，如果跟随对象被销毁后，此参数将起到作用
    /// </summary>
    private Vector3 lastPosition = Vector3.one;

    /// <summary>
    /// 用于记录物品是否已经执行过销毁命令
    /// </summary>
    private bool isDestroy = false;

    /// <summary>
    /// Cache the transform;
    /// </summary>

    void Awake() { mTrans = transform; }

    /// <summary>
    /// Find both the UI camera and the game camera so they can be used for the position calculations
    /// </summary>

    void Start()
    {
        if (target != null)
        {
            if (gameCamera == null) gameCamera = HUDRoot.instance.gameCamera;
            if (uiCamera == null) uiCamera = HUDRoot.instance.uiCamera;
            SetVisible(false);
        }
        else
        {
            Debug.LogError("Expected to have 'target' set to a valid transform", this);
            enabled = false;
        }
    }

    /// <summary>
    /// Enable or disable child objects.
    /// </summary>

    void SetVisible(bool val)
    {
        mIsVisible = val;

        for (int i = 0, imax = mTrans.childCount; i < imax; ++i)
        {
            NGUITools.SetActive(mTrans.GetChild(i).gameObject, val);
        }
    }

    /// <summary>
    /// Update the position of the HUD object every frame such that is position correctly over top of its real world object.
    /// </summary>

    void Update()
    {
        if (target == null)
        {
            if (!isDestroy)
            {
                isDestroy = true;
                Destroy(gameObject, 3f);
            }
        }
        else
        {
            lastPosition = target.position;
        }

        Vector3 pos = gameCamera.WorldToViewportPoint(lastPosition);

        // Determine the visibility and the target alpha
        bool isVisible = (gameCamera.orthographic || pos.z > 0f) && (!disableIfInvisible || (pos.x > 0f && pos.x < 1f && pos.y > 0f && pos.y < 1f));

        // Update the visibility flag
        if (mIsVisible != isVisible) SetVisible(isVisible);

        // If visible, update the position
        if (isVisible)
        {
            transform.position = uiCamera.ViewportToWorldPoint(pos);
            pos = mTrans.localPosition;
            pos.x = Mathf.FloorToInt(pos.x);
            pos.y = Mathf.FloorToInt(pos.y);
            pos.z = 0f;
            mTrans.localPosition = pos;
        }
        OnUpdate(isVisible);
    }

    /// <summary>
    /// Custom update function.
    /// </summary>

    protected virtual void OnUpdate(bool isVisible) { }
}
