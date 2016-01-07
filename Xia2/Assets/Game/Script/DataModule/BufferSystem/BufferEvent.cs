public enum BufferEvent{
	AddHpMax = 1,										// + max Hp  						!
	AddAtackStrength = 2,								// + 攻击力    						！
	AddArmor = 3,										// + 护甲 	  						！
	AddCritLv = 4,										// + 暴击等级  						！
	AddToughnessLv = 5,									// + 韧性等级  						！
	AddDodgeLv = 6,									    // + 闪避等级  						！
	AddHitLv = 7,										// + 命中等级  						！
	IngoreDefense = 8,									// 忽略防御/护甲 						！
	ReflectDamage = 9,									// 反伤								!
	AddAtackSpeed = 10,									// + 攻击速度 						！
	Silent = 11,										// 沉默 								！
	AtackCombosOne = 12,								// 普通攻击一次 额外会再攻击一次			! state , i
	Shackles = 13,										// 束缚  							！
	ImmuneAllDamage = 14,								// 免疫所有伤害 						！
	DamageDouble = 15,									// 双倍伤害							！ state , i
	Vertigo = 16,										// 眩晕 								！
	DelWalkSpeed = 17,									// 减移动速度 						！
	AddWalkSpeed = 18,									// 加移动速度 						！
	AddManaPoint = 19,									// 无双翻倍?? 						！ state , i
	SustainedAddHp = 20,								// 持续加血 							！
	SustainedDelHp = 21,								// 持续掉血 							！
	UpDamage = 22,										// 被攻击的伤害提升					！state , i
	HpToZeroAndAddHp = 23,								// 持续掉血 掉完后给自己加血
	SkillDamageUp = 24,									// 技能伤害提升 						！	state , i 
	AllDamageUp = 25,									// 整体伤害提升						！	state , i
	Charm = 26,											// 魅惑 								！ 
	DelDefense = 27,									// 减少防御 							！
	DelHit = 28,										// 减少命中 							！
	DelAtackStrength = 29 ,								// 减少min 攻击力和max 攻击力  ?? 		！
	DelSkillCd = 30,									// 减技能cd							！ 	state , i
	AtackNTAddHp = 31,									// 打n次吸血
	AddAttackByHp = 32,									// 添加攻击力，增加的数值与当前血量相关	!
	CriticalCertain = 33,								// 必然暴击                          ！
	ShieldBoom = 34,									// 护盾爆
	CumulativeThreeAtk = 35,							// 没第3次攻击造成大量伤害
	ReflectDamageAddHp = 36,							// 给自己回复反伤的伤害								!
	SkillNotUseMp = 37,									// 使用技能不消耗Mp
	AutoAddMp = 38,										// 自动回复能量
}
//1--------+max hp
//2--------+min 攻击力和max 攻击力
//3--------+护甲
//4--------+暴击等级
//5--------+韧性等级
//6--------+闪避等级
//7--------+命中等级
//8--------忽略护甲
//9--------反伤
//10--------+攻击速度
//11--------沉默
//12--------普通攻击一次 额外会再攻击一次
//13--------束缚
//14--------免疫所有伤害
//15--------双倍伤害
//16--------眩晕
//17--------减移动速度
//18--------加移动速度
//19--------无双翻倍？
//20--------持续加血
//21--------持续掉血
//22--------被攻击的伤害提升
//23--------持续掉血 掉完给自己加血
//24--------技能伤害提升
//25--------整体伤害提升
//26--------魅惑
//27--------减少护甲
//28--------减少命中
//29--------减少min 攻击力和max 攻击力
//30--------减少技能cd
//31--------打n次吸血
//32--------

