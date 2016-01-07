using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//从配置表中读取的章节配置数据
public class ChapterItem : BaseItem{
	public const int MAX_DUNGEON_NUM = 99;
	
	private Dictionary<int , int> dungeonIdDic;
	
	public int id{
		get{
			return templateID;
		}
		set{
			templateID = value;
		}
	}
	
	public int openLv{get{return StaticChapter.Instance().getInt(templateID , "openlv");}}
	
	public int nextId{get{return StaticChapter.Instance().getInt(templateID , "nxtid");}}
	
	public string name{get{return StaticChapter.Instance().getStr(templateID ,"name");}}
	
	public int starCount{get{return StaticChapter.Instance().getInt(templateID , "starcount");}}
	
	public int box1Id{get{return StaticChapter.Instance().getInt(templateID , "box1");}}
	
	public int box2Id{get{return StaticChapter.Instance().getInt(templateID , "box2");}}
	
	public int box3Id{get{return StaticChapter.Instance().getInt(templateID , "box3");}}
	
	public int box4Id{get{return StaticChapter.Instance().getInt(templateID , "box4");}}
		
	public ChapterItem(int id){
		this.id = id;
		ReadChapterDungeonIds();
	}
	
	void ReadChapterDungeonIds(){
		dungeonIdDic = new Dictionary<int, int>();
		for(int index = 1 ; index <= MAX_DUNGEON_NUM ; index ++){
			int id = getDungeonId(index);
			if(id != 0){
				dungeonIdDic.Add(index , id);
			}else
				break;
		}
	}
	
	int getDungeonId(int index){
		return StaticChapter.Instance().getInt(templateID , "dg" + intTostringFormat(index));
	}
	
	string intTostringFormat(int value){
		return string.Format("{0:D2}",value);
	}
	
	public Dictionary<int , int> GetDungeonIdDic(){
		return dungeonIdDic;
	}
	
	public int GetDungeonId(int index){
		return dungeonIdDic[index];
	}

    public void Reset(int id)
    {
        this.id = id;
        ReadChapterDungeonIds();
    }

    private int[] mDungeonIds;
    public int[] GetAllDungeonId()
    {
        if(mDungeonIds ==null)
        {
            List<int> ids = new List<int>();

            foreach (int id in GetDungeonIdDic().Values)
            {
                ids.Add(id);
            }
            mDungeonIds = ids.ToArray();
        }
        return mDungeonIds;
    }

    public void ResetIDs() { mDungeonIds = null; }
}