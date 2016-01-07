using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using FightMessage;

public class Monster_efs : MonoBehaviour
{

    private static Monster_efs mInstance;
    public static Monster_efs instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = GameObject.FindObjectOfType(typeof(Monster_efs)) as Monster_efs;
            }
            return mInstance;
        }
    }


    const int MONNUM = 30;
    const int SHORTMONNUM = 25;

    public Transform shadow;
    public Transform ef_hit;
    public Transform ef_blood;
    public Transform ef_block;
    public Transform arrowmark;
    public Transform num_damage;
    public Transform pt_itemdrop;
	public Transform ef_item;

    //added by wp
    //public Transform ef_sprayBlood;

    public Texture[] attribute_tex = new Texture[4];
    public Material[] blood_mat = new Material[5];

    public Material split_material;
    public Material item_material;
    public Material main_material;
    public Material hp_bar;

    public AnimationClip[] begrab = new AnimationClip[6];
    public AnimationClip[] bethrust = new AnimationClip[6];
    public AnimationClip[] bekicked = new AnimationClip[6];
    public AnimationClip[] getup = new AnimationClip[6];
    public AnimationClip pierce;
    public AnimationClip[] summon = new AnimationClip[2];

    public float[] speed_begrab = new float[7];
    public float[] speed_bethrust = new float[7];
    public float[] speed_bekicked = new float[7];
    public float[] speed_getup = new float[7];
    public int[] force_grab = new int[7];
    public int[] force_kick = new int[7];

    public AudioClip[] snd_move = new AudioClip[3];
    public AudioClip[] snd_scream = new AudioClip[4];

    //public AudioClip[] snd_attack = new AudioClip[3];

    Transform mytransform;
    Transform[] c_shadow = new Transform[MONNUM];
    int selectshadow;
    Transform grab_blood;
    ///Transform[] c_damagenum = new Transform[SHORTMONNUM];
    Transform[] c_ef_hit = new Transform[SHORTMONNUM];
    Transform[] c_ef_blood = new Transform[SHORTMONNUM];
    Transform[] c_ef_split = new Transform[SHORTMONNUM];

    //add by wp
    //Transform[] c_ef_sprayBlood = new Transform[SHORTMONNUM];

    Transform[] c_hpbar = new Transform[MONNUM];
    Transform[] c_item = new Transform[MONNUM];
    Mesh[] m_item = new Mesh[MONNUM];

    Transform selecthpbar;
    Vector2 hpsize = new Vector2(0.05f, 0.01f);
    int count_item = 0;
    int count_damagenum = 0;
    //int plusrate = 0;
    int ef_attribute = 0;

    //Transform[] c_ef_block = new Transform[SHORTMONNUM];
    //Transform[] c_arrowmark = new Transform[SHORTMONNUM];

    Vector3 originpos = Vector3.one * 3;

    public bool story = false;
    bool infinitymode = false;
    int index_ef = 0;
    int index_destroy = 0;
    //Spawn script_spawn;
    ///Spawn_story script_spawn_story;

    float limit_x = 2.65f;
    float limit_y_b = -2.6f;
    float limit_y_f = 2.5f;

    Transform m_shadow;

    void Awake()
    {
        mytransform = transform;

        for (int i = 0; i < MONNUM; ++i)
        {
            c_hpbar[i] = CreatHpbar(hpsize, false, false);
            c_hpbar[i].position = Vector3.one * 4;

            c_shadow[i] = (Transform)Instantiate(shadow, originpos, Quaternion.identity);
            c_shadow[i].parent = transform;
            c_shadow[i].gameObject.active = false;

        }
        for (int i = 0; i < SHORTMONNUM; ++i)
        {
            ///c_damagenum[i] = (Transform)Instantiate(num_damage, originpos,num_damage.rotation);
            c_ef_hit[i] = (Transform)Instantiate(ef_hit, originpos, Quaternion.identity);
            c_ef_blood[i] = (Transform)Instantiate(ef_blood, originpos, Quaternion.identity);
            c_ef_hit[i].parent = transform;
            c_ef_blood[i].parent = transform;
            //added by wp
            //c_ef_sprayBlood[i] = (Transform)Instantiate(ef_sprayBlood, originpos, Quaternion.identity);
            //c_ef_sprayBlood[i].parent = mytransform;

            c_ef_split[i] = SplitOn((i + 1) % 4);
            c_ef_split[i].position = originpos;

            c_ef_hit[i].parent = mytransform;
            c_ef_blood[i].parent = mytransform;
            c_ef_split[i].parent = mytransform;

            c_item[i] = CreatItemBox();
            c_item[i].position = Vector3.one * 5;
            //c_ef_block[i] = (Transform)Instantiate(ef_block, originpos,Quaternion.identity);
        }
    }

    void Start()
    {
        if (!story)
        {
            //script_spawn = GameObject.FindWithTag("Respawn").GetComponent<Spawn>();
            //infinitymode = script_spawn.infinitymode;
            //TODO by wp:
        }
        else
        {
            ///script_spawn_story = GameObject.FindWithTag("Respawn").GetComponent<Spawn_story>();
        }



        grab_blood = (Transform)Instantiate(ef_blood, originpos, Quaternion.identity);
        grab_blood.parent = mytransform;
        grab_blood.localScale = new Vector3(0.5f, 1.2f, 1.2f);
        count_item = 0;

        speed_begrab[0] = 0.25f;		//////// giant swing
        speed_bethrust[0] = 0.5f;
        speed_bekicked[0] = 0.20f;
        speed_getup[0] = 0.25f;

        speed_begrab[1] = 0.28f;		//////// ground smash
        speed_bethrust[1] = 0.28f;
        speed_bekicked[1] = 0.25f;
        speed_getup[1] = 0.25f;

        speed_begrab[2] = 0.24f;		//////// heaven spear
        speed_bethrust[2] = 0.28f;
        speed_bekicked[2] = 0.25f;
        speed_getup[2] = 0.25f;

        ///////////////////////////big size
        speed_begrab[3] = 0.35f;			//////// riding kill
        speed_bethrust[3] = 0.25f;
        speed_bekicked[3] = 0.30f;
        speed_getup[3] = 0.25f;

        speed_begrab[4] = 0.4f;			//////// sliding tackle
        speed_bethrust[4] = 0.25f;
        speed_bekicked[4] = 0.25f;
        speed_getup[4] = 0.25f;

        speed_begrab[5] = 0.22f;			//////// over head
        speed_bethrust[5] = 0.25f;
        speed_bekicked[5] = 0.28f;
        speed_getup[5] = 0.25f;

        speed_begrab[6] = 0.35f;			//////// rolling kill
        speed_bethrust[6] = 0.35f;
        speed_bekicked[6] = 0.25f;
        speed_getup[6] = 0.25f;

        force_grab[0] = 40;
        force_grab[1] = 40;
        force_grab[2] = 30;
        force_grab[3] = 80;
        force_grab[4] = 60;
        force_grab[5] = 80;
        force_grab[6] = 60;

        force_kick[0] = -200;
        force_kick[1] = -10;
        force_kick[2] = -10;
        force_kick[3] = 240;
        force_kick[4] = 20;
        force_kick[5] = -160;
        force_kick[6] = -100;
    }

    public void FinishEfs()
    {
        for (int i = 0; i < SHORTMONNUM; ++i)
        {
            c_ef_split[i].GetComponent<Ef_split1>().FinishNow();
            c_item[i].GetComponent<Itemdrop>().Disappear();
        }
    }

    public void RestrictArea(float _limit_x, float _limit_y_b, float _limit_y_f)
    {
        limit_x = _limit_x;
        limit_y_b = _limit_y_b;
        limit_y_f = _limit_y_f;
    }

    public AudioClip ScreamSFX()
    {
        AudioClip scream = snd_scream[Random.Range(0, 4)];
        return scream;
    }

    public void BloodAttribute(int _index)
    {
        if (ef_attribute != _index)
        {
            for (int i = 0; i < SHORTMONNUM; ++i)
            {
                c_ef_blood[i].GetComponent<Renderer>().material = blood_mat[_index];
            }
        }
        ef_attribute = _index;
        //Debug.Log(ef_attribute);
    }

    public void EnemyDead(int _destroy, Vector3 _pos, Texture _tex, Vector3 _scale, Vector3 _forcedir, int enmeyId)
    {
        if (!story)
            EnemyCtrl.instance.EnemyDead(_destroy, _pos, _tex, _scale, _forcedir);
        ///		else
        ///			script_spawn_story.EnemyDead(_destroy,_pos,_tex,_scale,_forcedir);

        _pos[1] = 0;
        c_ef_split[index_destroy].gameObject.active = true;
        c_ef_split[index_destroy].position = _pos + _forcedir * (0.2f);
        c_ef_split[index_destroy].rotation = Quaternion.Euler(Vector3.up * Random.Range(0, 360));

        index_destroy = (index_destroy + 1) % SHORTMONNUM;
    }


    public int CreatShadow(Transform _mon, float _size)
    {
        for (int i = 0; i < 15; ++i)
        {
            if (c_shadow[i].position.y > 2)
            {
                selectshadow = i;
                break;
            }
        }
        c_shadow[selectshadow].position = Vector3.one * (-1);
        c_shadow[selectshadow].GetComponent<Shadow>().Pickparent(_mon, _size);
        c_shadow[selectshadow].gameObject.active = true;
        return selectshadow;
    }

    public void DestroyShadow(int _index)
    {
        c_shadow[_index].GetComponent<Shadow>().Finish();
    }

    public void SetDamageNum(Vector3 _pos, short _damage, Vector3 _dir)
    {
        ///c_damagenum[count_damagenum].GetComponent<DamageNum>().TextOn(_pos,_damage,_dir);
        //c_damagenum[count_damagenum].gameObject.active = true;
        //c_damagenum[count_damagenum].position = _pos + Vector3.up*0.1f; 
        //c_damagenum[count_damagenum].GetComponent<TextMesh>().text = _damage.ToString();
        count_damagenum = (count_damagenum + 1) % 10;
    }

    public void CreatBlood(Vector3 _pos, Vector3 _dir)
    {
        c_ef_blood[index_ef].gameObject.SetActive(true);
        //c_ef_blood[index_ef].position = _pos + Vector3.up * 0.05f;

        c_ef_blood[index_ef].position = _pos + _dir * (0.1f) + Vector3.up * 0.05f;

        ////added by wp
        //c_ef_sprayBlood[index_ef].gameObject.SetActive(true);
        //c_ef_sprayBlood[index_ef].position = _pos + Vector3.up * 0.05f;

        if (_dir != Vector3.zero)
        {
            c_ef_blood[index_ef].rotation = Quaternion.LookRotation(_dir);
            //c_ef_sprayBlood[index_ef].rotation = Quaternion.LookRotation(-_dir);
        }

//        c_ef_hit[index_ef].gameObject.SetActive(true);
//        c_ef_hit[index_ef].position = _pos + _dir * (-0.1f) + Vector3.up * 0.05f;
//        c_ef_hit[index_ef].rotation = Quaternion.Euler(Vector3.up * Random.Range(0, 360));

        index_ef = (index_ef + 1) % SHORTMONNUM;
        //CreatBlood_Only(_pos, _dir);
    }

    public void CreatHitEffect_Only(Vector3 _pos, Vector3 _dir)
    {
        //Debug.Log("set eff", c_ef_hit[index_ef].gameObject);

		//Fix: Test for

		c_ef_blood[index_ef].gameObject.SetActive(true);
		c_ef_blood[index_ef].position = _pos + _dir*(0.1f) + Vector3.up * 0.05f;
		
		if (_dir != Vector3.zero)
		{
			c_ef_blood[index_ef].rotation = Quaternion.LookRotation(-_dir);
		}
//        c_ef_hit[index_ef].gameObject.SetActive(true);
//        c_ef_hit[index_ef].position = _pos + _dir * (-0.1f) + Vector3.up * 0.05f;
//        c_ef_hit[index_ef].rotation = Quaternion.Euler(Vector3.up * Random.Range(0, 360));

        index_ef = (index_ef + 1) % SHORTMONNUM;
    }

    public void CreatGrabBlood(Vector3 _pos, Quaternion _dir)
    {
        grab_blood.gameObject.active = true;
        grab_blood.position = _pos;
        grab_blood.rotation = _dir;
    }

    public Transform SplitOn(int _rnduv)
    {
        Vector2 rndVector = Vector2.zero;
        switch (_rnduv)
        {
            case 0:
                rndVector = Vector2.up * 0.5f;
                break;
            case 1:
                rndVector = Vector2.one * 0.5f;
                break;
            case 2:
                rndVector = Vector2.zero * 0.5f;
                break;
            case 3:
                rndVector = Vector2.right * 0.5f;
                break;
        }

        GameObject c_plane = new GameObject("split");
        MeshFilter meshFilter = c_plane.AddComponent<MeshFilter>();
        Mesh c_mesh = new Mesh();

        c_plane.AddComponent<MeshRenderer>();

        float _size = Random.Range(0.15f, 0.2f);
        c_mesh.vertices = new Vector3[]
		{                    
			new Vector3(-_size,0.005f, _size) , new Vector3(_size,0.005f,_size),             
			new Vector3(-_size, 0.005f, -_size), new Vector3(_size,0.005f,-_size)        
		};

        c_mesh.name = "splitmesh";

        c_mesh.uv = new Vector2[]
		{         
			Vector2.up*0.5f +rndVector, Vector2.one*0.5f +rndVector,      
			Vector2.zero +rndVector ,Vector2.right *0.5f +rndVector    
		};

        c_mesh.triangles = new int[] { 0, 1, 2, 2, 1, 3 };
        c_mesh.RecalculateNormals();

        Renderer creatrender = c_plane.GetComponent<Renderer>();
        creatrender.receiveShadows = false;
        creatrender.castShadows = false;
        creatrender.sharedMaterial = split_material;
        creatrender.sharedMaterial.renderQueue = 2002;

        meshFilter.mesh = c_mesh;

        c_plane.AddComponent<Ef_split1>();
        //Destroy(c_plane,4.0f);
        return c_plane.transform;
    }

    /*public void CreatBlock(Vector3 _pos, Vector3 _dir)
    {
        Instantiate (ef_block,_pos - _dir*0.1f,Quaternion.LookRotation(-_dir));
    }*/

    public void DirectionArrow()
    {
    }

    public Transform SetHpbar()
    {
        for (int i = 0; i < MONNUM; ++i)
        {
            if (c_hpbar[i].position.y > 2)
            {
                selecthpbar = c_hpbar[i];
                break;
            }
        }
        return selecthpbar;
    }

    public Transform CreatHpbar(Vector2 _size, bool _turretmode, bool _ally)
    {
        GameObject c_plane = new GameObject("hp_bar");
        MeshFilter meshFilter = c_plane.AddComponent<MeshFilter>();
        Mesh c_mesh = new Mesh();

        c_plane.AddComponent<MeshRenderer>();

        c_mesh.vertices = new Vector3[]
		{                    
			new Vector3(-_size.x, _size.y, 0) *0.5f, new Vector3(_size.x, _size.y,0)*0.5f,             
			new Vector3(-_size.x, -_size.y, -0.02f)*0.5f, new Vector3(_size.x, -_size.y, -0.02f) *0.5f       
		};

        float f_ally = 0;
        if (_ally)
            f_ally = 0.75f;
        c_mesh.uv = new Vector2[]
		{         
			new Vector2(0, 0.25f+f_ally), new Vector2(0.5f,0.25f+f_ally),      
			new Vector2(0, f_ally), new Vector2(0.5f,f_ally)     
		};
        Renderer creatrender = c_plane.GetComponent<Renderer>();

        creatrender.receiveShadows = false;
        creatrender.castShadows = false;

        creatrender.sharedMaterial = hp_bar;

        c_mesh.triangles = new int[] { 0, 1, 2, 2, 1, 3 };
        c_mesh.RecalculateNormals();
        meshFilter.mesh = c_mesh;

        c_plane.transform.parent = mytransform;

        if (!_turretmode)
            c_plane.AddComponent<Hp_bar>();
        else
        {
            UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(c_plane, "Assets/Game/Script/Monster/Monster_efs.cs (467,13)", "Hp_bar_fixed");
        }
        return c_plane.transform;
    }

    public void SetItemBox(int _level, Vector3 _pos, List<DropItem> items)
    {
        //Todo Lee Test
        //		items.Clear ();
        //		for (int i = 0; i < 3; i++) {
        //			DropItem item = new DropItem();
        //			item.id = 1;
        //			item.number = 1;
        //			item.type = 8;
        //			items.Add (item);		
        //		}


        for (int i = 0; i < items.Count; i++)
        {
            int type = items[i].type;
            if (type <= 0)
                continue;
            Vector2 offset = Vector2.zero;
            float _size = 0;

            int tmp_type = 0;
            if (type == 8)
                tmp_type = 0;
            else if (type == 1)
                tmp_type = 1;
            else
                tmp_type = 2;

            int uIndex = tmp_type % 4;
            int vIndex = (int)(tmp_type / 4);
            offset = new Vector2(uIndex * 0.25f, 1.0f - 0.25f - vIndex * 0.25f);
            _size = 0.25f;

            m_item[count_item].uv = new Vector2[]
			{
				offset + Vector2.up*_size,offset + Vector2.one*_size,
				offset,offset + Vector2.right*_size
			};

            _pos[0] = Mathf.Clamp(_pos[0], -limit_x, limit_x);
            _pos[2] = Mathf.Clamp(_pos[2], limit_y_b, limit_y_f);
            c_item[count_item].position = _pos + Vector3.up * 0.1f;

            c_item[count_item].GetComponent<Itemdrop>().Whatsindex(items[i].id, _level, items[i]);
            c_item[count_item].gameObject.active = true;
            count_item = (count_item + 1) % SHORTMONNUM;
        }
    }

    public Transform CreatItemBox()
    {
        GameObject c_plane = new GameObject("itemBox");
        MeshFilter meshFilter = c_plane.AddComponent<MeshFilter>();
        Mesh c_mesh = new Mesh();

        c_plane.AddComponent<MeshRenderer>();

        c_mesh.vertices = new Vector3[]
		{                    
			new Vector3(-0.035f, 0.05f, 0.05f), new Vector3(0.035f, 0.05f,  0.05f),     
			Vector3.right*-0.035f,  Vector3.right *0.035f
		};

        c_mesh.uv = new Vector2[]
		{         
			Vector2.up, Vector2.one,      
			Vector2.zero, Vector2.right     
		};
        Renderer creatrender = c_plane.GetComponent<Renderer>();

        creatrender.receiveShadows = false;
        creatrender.castShadows = false;

        creatrender.sharedMaterial = item_material;

        SphereCollider scollider = c_plane.AddComponent<SphereCollider>();
        scollider.radius = 0.08f;
        scollider.enabled = false;
        scollider.isTrigger = true;
//
//		SphereCollider scollider1 = c_plane.AddComponent<SphereCollider>();
//		scollider1.radius = 0.06f;
//		scollider1.enabled = true;
//		scollider1.isTrigger = false;

		Rigidbody rigid = c_plane.AddComponent<Rigidbody> ();
		rigid.useGravity = false;
		rigid.drag = 5;
		rigid.mass = 1;
		rigid.angularDrag = 5;
		rigid.constraints = RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezeRotationX|RigidbodyConstraints.FreezeRotationZ;


        c_mesh.triangles = new int[] { 0, 1, 2, 2, 1, 3 };
        c_mesh.RecalculateNormals();
        meshFilter.mesh = c_mesh;
        m_item[count_item] = c_mesh;
        ++count_item;

        c_plane.transform.parent = mytransform;
        c_plane.layer = 13;
        c_plane.AddComponent<Itemdrop>();

        c_plane.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

		Transform ef;
		ef = (Transform)Instantiate (ef_item,c_plane.transform.position,c_plane.transform.rotation );
		ef.transform.parent = c_plane.transform;
		ef.gameObject.SetActive (true);

        return c_plane.transform;
    }
}
