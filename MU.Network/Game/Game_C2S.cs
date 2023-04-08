﻿using MU.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using WebZen.Serialization;
using WebZen.Util;

namespace MU.Network.Game
{
    [WZContract]
    public class CCheckSum : IGameMessage
    {
        [WZMember(0)]
        public ushort Key { get; set; }
    }

    [WZContract]
    public class CClientMessage : IGameMessage
    {
        [WZMember(0)]
        public HackCheck Flag { get; set; }
    }

    [WZContract]
    public class CCloseWindow : IGameMessage
    { }

    [WZContract]
    public class CCancelItemSale : IGameMessage
    { }

    [WZContract]
    public class CCancelItemSaleClose : IGameMessage
    { }

    [WZContract]
    public class CCancelItemSaleItem : IGameMessage
    {
        [WZMember(0)] public byte IndexCode { get; set; }
        [WZMember(1)] public ushort Unk { get; set; }
        [WZMember(2)] public byte ItemCount { get; set; }
        [WZMember(3)] public uint ExpireSec { get; set; }
        [WZMember(4)] public int RequireMoney { get; set; }
        [WZMember(5)] public int Unk2 { get; set; }
    }

    [WZContract]
    public class CTeleport : IGameMessage
    {
        [WZMember(0)] public byte Unk { get; set; }
        [WZMember(1)] public ushort MoveNumber { get; set; }
        [WZMember(2)] public byte X { get; set; }
        [WZMember(3)] public byte Y { get; set; }
        [WZMember(4)] public byte Unk2 { get; set; }

        //public ushort MoveNumber => wzMoveNumber.ShufleEnding();
    }

    [WZContract]
    public class CTeleportS9 : IGameMessage
    {
        [WZMember(0)] public byte fix { get; set; }
        [WZMember(1)] public ushort MoveNumber { get; set; }
        [WZMember(2)] public byte X { get; set; }
        [WZMember(3)] public byte Y { get; set; }

        //public ushort MoveNumber => wzMoveNumber.ShufleEnding();
    }

    [WZContract]
    public class CAction : IGameMessage
    {
        [WZMember(0)]
        public byte Dir { get; set; }

        [WZMember(1)]
        public byte ActionNumber { get; set; }

        //[WZMember(2)]
        public ushort btTarget { get; set; }

        public ushort Target
        {
            get => btTarget.ShufleEnding();
            set
            {
                btTarget = value.ShufleEnding();
            }
        }
    }

    [WZContract]
    public class CMove : IGameMessage
    {
        [WZMember(0)]
        public byte X { get; set; } // 3

        [WZMember(1)]
        public byte Y { get; set; } // 4

        [WZMember(2, 8)]
        public byte[] Path { get; set; }   // 5 - 8
    }

    [WZContract]
    public class CMoveEng : IGameMessage
    {
        [WZMember(0)]
        public byte X { get; set; } // 3

        [WZMember(1)]
        public byte Y { get; set; } // 4

        [WZMember(2, 8)]
        public byte[] Path { get; set; }   // 5 - 8
    }

    [WZContract]
    public class CMove12Eng : IGameMessage
    {
        [WZMember(0)]
        public byte X { get; set; } // 3

        [WZMember(1)]
        public byte Y { get; set; } // 4

        [WZMember(2, 8)]
        public byte[] Path { get; set; }   // 5 - 8
    }

    [WZContract]
    public class CChatNickname : IGameMessage
    {
        [WZMember(0, 10)]
        public byte[] Character { get; set; } // 3

        [WZMember(1, 60)]
        public byte[] Message { get; set; } // 4
    }

    [WZContract]
    public class CChatNumber : IGameMessage
    {
        [WZMember(0)]
        public ushort wzNumber { get; set; } // 3

        [WZMember(1, 60)]
        public byte[] Message { get; set; } // 4

        public ushort Number { get => wzNumber.ShufleEnding(); set => wzNumber = value.ShufleEnding(); }
    }

    [WZContract]
    public class CChatWhisper : IGameMessage
    {
        [WZMember(0, 10)]
        public byte[] btId { get; set; }    // 3

        [WZMember(1, 60)]
        public byte[] btMessage { get; set; }   // D  

        public string Id => btId.MakeString();

        public string Message => btMessage.MakeString();
    };

    [WZContract]
    public class CPositionSet : IGameMessage
    {
        [WZMember(0)]
        public byte X { get; set; }

        [WZMember(1)]
        public byte Y { get; set; }

        public Point Position => new Point(X, Y);
    }

    [WZContract]
    public class CPositionSetS9 : IGameMessage
    {
        [WZMember(0)]
        public byte X { get; set; }

        [WZMember(1)]
        public byte Y { get; set; }

        public Point Position => new Point(X, Y);
    }

    [WZContract]
    public class CPointAdd : IGameMessage
    {
        [WZMember(0)]
        public PointAdd Type { get; set; }
    }

    [WZContract]
    public class CClientClose : IGameMessage
    {
        [WZMember(0)]
        public ClientCloseType Type { get; set; }
    }

    [WZContract]
    public class CMoveItem : IGameMessage
    {
        [WZMember(0)]
        public MoveItemFlags sFlag { get; set; }

        [WZMember(1)]
        public byte Source { get; set; }

        [WZMember(2, 12)]
        public byte[] ItemInfo { get; set; }

        [WZMember(3)]
        public MoveItemFlags tFlag { get; set; }

        [WZMember(4)]
        public byte Dest { get; set; }
    }

    [WZContract]
    public class CUseItem : IGameMessage
    {
        [WZMember(0)]
        public byte Source { get; set; }

        [WZMember(1)]
        public byte Dest { get; set; }

        [WZMember(2)]
        public byte Type { get; set; }
    }

    [WZContract]
    public class CItemGet : IGameMessage
    {
        [WZMember(0)]
        public ushort wzNumber { get; set; }

        public ushort Number => wzNumber.ShufleEnding();
    }

    [WZContract]
    public class CEventEnterCount : IGameMessage
    {
        [WZMember(0)]
        public EventEnterType Type { get; set; }
    }

    [WZContract]
    public class CTalk : IGameMessage
    {
        [WZMember(0)]
        public ushort Number { get; set; }
    }

    [WZContract]
    public class CWarehouseUseEnd : IGameMessage
    { }

    [WZContract]
    public class CBuy : IGameMessage
    {
        [WZMember(0)]
        public byte Position { get; set; }
    }

    [WZContract]
    public class CSell : IGameMessage
    {
        [WZMember(0)]
        public byte Position { get; set; }
    }

    [WZContract]
    public class CAttack : IGameMessage
    {
        [WZMember(0)]
        public ushort wzNumber { get; set; }   // 3,4

        [WZMember(1)]
        public byte AttackAction { get; set; }  // 5

        [WZMember(2)]
        public byte DirDis { get; set; }    // 6

        public ushort Number => wzNumber.ShufleEnding();
    }

    [WZContract]
    public class CAttackS5E2 : IGameMessage
    {
        [WZMember(0)]
        public byte AttackAction { get; set; }  // 5

        [WZMember(1)]
        public byte DirDis { get; set; }    // 6

        [WZMember(2)]
        public ushort Number { get; set; }   // 3,4
    }

    [WZContract]
    public class CMagicAttack : IGameMessage
    {
        [WZMember(0)]
        public ushort wzMagicNumber { get; set; }

        [WZMember(1)]
        public ushort wzTarget { get; set; }

        [WZMember(2)]
        public byte Dis { get; set; }

        public ushort Target { get => wzTarget.ShufleEnding(); set => wzTarget = value.ShufleEnding(); }
        public Spell MagicNumber { get => (Spell)wzMagicNumber.ShufleEnding(); set => wzMagicNumber = ((ushort)value).ShufleEnding(); }
    }

    [WZContract]
    public class CMagicAttackS9 : IGameMessage
    {
        [WZMember(0)]
        public byte TargetH { get; set; }

        [WZMember(1)]
        public byte MagicNumberH { get; set; }
        [WZMember(2)]
        public byte TargetL { get; set; }

        [WZMember(3)]
        public byte MagicNumberL { get; set; }

        public ushort Target => (ushort)(TargetH << 8 | TargetL);
        public Spell MagicNumber => (Spell)(MagicNumberH << 8 | MagicNumberL);
    }

    [WZContract]
    public class CMagicDuration : IGameMessage
    {
        [WZMember(0)]
        public ushort wzMagicNumber { get; set; }
        [WZMember(1)]
        public byte X { get; set; }
        [WZMember(2)]
        public byte Y { get; set; }
        [WZMember(3)]
        public byte Dir { get; set; }
        [WZMember(4)]
        public byte Dis { get; set; }
        [WZMember(5)]
        public byte TargetPos { get; set; }

        [WZMember(6)]
        public ushort wzTarget { get; set; }

        [WZMember(7)]
        public byte MagicKey { get; set; }

        [WZMember(8, 5)]
        public byte[] Unk { get; set; }

        public ushort Target { get => wzTarget.ShufleEnding(); set => wzTarget = value.ShufleEnding(); }
        public Spell MagicNumber
        {
            get => (Spell)wzMagicNumber.ShufleEnding();
            set => wzMagicNumber = ((ushort)value).ShufleEnding();
        }
    }

    [WZContract]
    public class CMagicDurationS9 : IGameMessage
    {
        [WZMember(0)] public byte X { get; set; }
        [WZMember(1)] public byte MagicNumberH { get; set; }
        [WZMember(2)] public byte Y { get; set; }
        [WZMember(3)] public byte MagicNumberL { get; set; }
        [WZMember(4)] public byte Dir { get; set; }

        [WZMember(5)] public byte TargetH { get; set; }
        [WZMember(6)] public byte Dis { get; set; }

        [WZMember(7)] public byte TargetL { get; set; }

        [WZMember(8)] public byte TargetPos { get; set; }

        [WZMember(9)] public byte MagicKey { get; set; }

        public ushort Target => (ushort)(TargetH << 8 | TargetL);
        public Spell MagicNumber => (Spell)(MagicNumberH << 8 | MagicNumberL);
    }

    [WZContract]
    public class CMagicDurationS16 : IGameMessage
    {
        [WZMember(0)] public int X { get; set; }
        [WZMember(1)] public byte MagicNumberH { get; set; }
        [WZMember(2)] public int Y { get; set; }
        [WZMember(3)] public byte MagicNumberL { get; set; }
        [WZMember(4)] public byte Dir { get; set; }

        [WZMember(5)] public byte TargetH { get; set; }
        [WZMember(6)] public byte Dis { get; set; }

        [WZMember(7)] public byte TargetL { get; set; }

        [WZMember(8)] public byte TargetPos { get; set; }

        [WZMember(9)] public byte MagicKey { get; set; }
        //[WZMember(10)] public uint AttackTime { get; set; }

        public ushort Target => (ushort)(TargetH << 8 | TargetL);
        public Spell MagicNumber => (Spell)(MagicNumberH << 8 | MagicNumberL);
    }

    [WZContract]
    public class CBeattackDto
    {
        [WZMember(0)] public ushort wzNumber { get; set; }
        [WZMember(1)] public byte MagicKey { get; set; }

        public ushort Number => wzNumber.ShufleEnding();
    }

    [WZContract]
    public class CBeattack : IGameMessage
    {
        [WZMember(0)] public ushort wzMagicNumber { get; set; }
        [WZMember(1)] public byte X { get; set; }
        [WZMember(2)] public byte Y { get; set; }
        [WZMember(3)] public byte Serial { get; set; }
        //[WZMember(1)] public byte Count { get; set; }
        [WZMember(4, typeof(ArrayWithScalarSerializer<byte>))] public CBeattackDto[] Beattack { get; set; }

        public Spell MagicNumber => (Spell)wzMagicNumber.ShufleEnding();
        public Point Position => new Point(X, Y);
    }

    [WZContract]
    public class CBeattackS9Dto
    {
        [WZMember(0)] public byte NumberH { get; set; }   // 0
        [WZMember(1)] public byte MagicKey { get; set; }  // 1
        [WZMember(2)] public byte NumberL { get; set; }	// 2

        public ushort Number => (ushort)(NumberH << 8 | NumberL);
    }

    [WZContract]
    public class CBeattackS9 : IGameMessage
    {
        [WZMember(0)] public byte MagicNumberH { get; set; }
        [WZMember(1)] public byte Count { get; set; }
        [WZMember(2)] public byte MagicNumberL { get; set; }
        [WZMember(3)] public byte X { get; set; }
        [WZMember(4)] public byte Serial { get; set; }
        [WZMember(5)] public byte Y { get; set; }
        //[WZMember(1)] public byte Count { get; set; }
        [WZMember(6, typeof(ArraySerializer))] public CBeattackS9Dto[] Beattack { get; set; }

        public Spell MagicNumber => (Spell)(MagicNumberH << 8 | MagicNumberL);
        public Point Position => new Point(X, Y);
    }

    [WZContract]
    public class CWarp : IGameMessage
    {
        [WZMember(0)]
        public int iCheckVal { get; set; }

        [WZMember(1)]
        public ushort MoveNumber { get; set; }
    }

    [WZContract]
    public class CDataLoadOK : IGameMessage
    { }

    [WZContract]
    public class CJewelMix : IGameMessage
    {
        [WZMember(0)]
        public byte JewelType { get; set; }

        [WZMember(1)]
        public byte JewelMix { get; set; }
    }

    [WZContract]
    public class CJewelUnMix : IGameMessage
    {
        [WZMember(0)]
        public byte JewelType { get; set; }

        [WZMember(1)]
        public byte JewelLevel { get; set; }

        [WZMember(2)]
        public byte JewelPos { get; set; }
    }

    [WZContract]
    public class CChaosBoxItemMixButtonClick : IGameMessage
    {
        //0xC1
        //0x05
        //0x86
        [WZMember(0)] public ChaosMixType Type { get; set; }
        [WZMember(1)] public byte Info { get; set; }
    }

    [WZContract]
    public class CChaosBoxItemMixButtonClickS5 : IGameMessage // Season 5 reference
    {
        [WZMember(0)] public ChaosMixType Type { get; set; }
        [WZMember(1)] public byte Info { get; set; }
    }

    [WZContract]
    public class CChaosBoxUseEnd : IGameMessage
    { }

    [WZContract]
    public class CInventory : IGameMessage
    { }

    [WZContract]
    public class CSkillKey : IGameMessage
    {
        [WZMember(0)]
        public byte subcode { get; set; }   // 3

        [WZMember(1, 20)]
        public byte[] SkillKey { get; set; }  // 4

        [WZMember(2)]
        public byte GameOption { get; set; }    // E

        [WZMember(3)]
        public byte QkeyDefine { get; set; }    // F

        [WZMember(4)]
        public byte WkeyDefine { get; set; }    // 10

        [WZMember(5)]
        public byte EkeyDefine { get; set; }    // 11

        [WZMember(6)]
        public byte ChatWindow { get; set; }    // 13

        [WZMember(7)]
        public byte RkeyDefine { get; set; }

        [WZMember(8)]
        public uint QWERLevelDefine { get; set; }
    }

    [WZContract]
    public class CItemThrow : IGameMessage
    {
        [WZMember(0)]
        public byte MapX { get; set; }   // 3

        [WZMember(1)]
        public byte MapY { get; set; }  // 4

        [WZMember(2)]
        public byte Source { get; set; }    // 5
    }

    [WZContract]
    public class CItemModify : IGameMessage
    {
        [WZMember(0)] public byte Position { get; set; }

        [WZMember(1)] public byte ReqPosition { get; set; }
    }

    [WZContract]
    public class CPShopSetItemPrice : IGameMessage
    {
        [WZMember(0)] public byte Position { get; set; }
        [WZMember(1)] public uint Price { get; set; }
        [WZMember(2)] public ushort JewelOfBlessPrice { get; set; }
        [WZMember(3)] public ushort JewelOfSoulPrice { get; set; }
        [WZMember(4)] public ushort JewelOfChaosPrice { get; set; }
    }

    [WZContract]
    public class CPShopSetItemPriceS16Kor : IGameMessage
    {
        [WZMember(0)] public byte Slot { get; set; }
        [WZMember(1)] public byte Changed { get; set; }
        [WZMember(2)] public uint Price { get; set; }
        [WZMember(3)] public uint JewelOfBlessPrice { get; set; }
        [WZMember(4)] public uint JewelOfSoulPrice { get; set; }
        [WZMember(5)] public uint Item1 { get; set; }
        [WZMember(6)] public uint Item2 { get; set; }
        [WZMember(7)] public uint Item3 { get; set; }
        [WZMember(8)] public uint Item4 { get; set; }
        [WZMember(9)] public uint Item5 { get; set; }

        private IEnumerable<uint> getItems()
        {
            var list = new List<uint>();
            if (Item1 != 0xffffffff) list.Add(Item1);
            if (Item2 != 0xffffffff) list.Add(Item2);
            if (Item3 != 0xffffffff) list.Add(Item3);
            if (Item4 != 0xffffffff) list.Add(Item4);
            if (Item5 != 0xffffffff) list.Add(Item5);

            return list;
        }

        public IEnumerable<uint> Items => getItems();
    }

    [WZContract]
    public class CPShopRequestOpen : IGameMessage
    {
        [WZMember(0, 36)] public byte[] btName { get; set; }

        public string Name => btName.MakeString();
    }

    [WZContract]
    public class CPShopRequestClose : IGameMessage
    { }

    [WZContract]
    public class CPShopRequestList : IGameMessage
    {
        [WZMember(0)] public ushort wzNumber { get; set; }
        [WZMember(1, 10)] public byte[] btName { get; set; }
        public ushort Number => wzNumber.ShufleEnding();
        public string Name => btName.MakeString();
    }

    [WZContract(LongMessage = true)]
    public class CPShopSearch : IGameMessage
    {
        [WZMember(0)] public uint Number { get; set; }
    }

    [WZContract(LongMessage = true)]
    public class CPShopItemSearch : IGameMessage
    {
        [WZMember(0)] public uint Number { get; set; }
    }

    [WZContract(LongMessage = true)]
    public class CPShopItemSearch2 : IGameMessage
    {
        [WZMember(0, typeof(BinaryStringSerializer), 65)] public string Name { get; set; }
        [WZMember(1)] public uint Number { get; set; }
        [WZMember(2)] public ushort Item { get; set; }
    }

    [WZContract(LongMessage = true)]
    public class CPShopRequestList2S16Kor : IGameMessage
    {
        [WZMember(0)] public uint Number { get; set; }
        [WZMember(1, typeof(BinaryStringSerializer), 11)] public string Seller { get; set; }
    }

    [WZContract(LongMessage = true)]
    public class CPShopChangeStateS16Kor : IGameMessage
    {
        [WZMember(0)] public uint Number { get; set; }
        [WZMember(1)] public byte State { get; set; }
        [WZMember(2, typeof(BinaryStringSerializer), 11)] public string Seller { get; set; }
        [WZMember(3, typeof(BinaryStringSerializer), 45)] public string Description { get; set; }
    }

    [WZContract(LongMessage = true)]
    public class CPShopCancelItemSaleS16Kor : IGameMessage
    {
        [WZMember(0)] public uint Number { get; set; }
        [WZMember(1, typeof(BinaryStringSerializer), 11)] public string Seller { get; set; }
        [WZMember(2)] public byte Slot { get; set; }
        [WZMember(3, typeof(ArrayWithScalarSerializer<uint>))] public ItemViewS16Dto[] Items { get; set; }
    }

    [WZContract(LongMessage = true)]
    public class CPShopItemViewS16Kor : IGameMessage
    {
        [WZMember(0)] public uint Number { get; set; }
        [WZMember(1, typeof(BinaryStringSerializer), 11)] public string Seller { get; set; }
        [WZMember(2)] public byte Slot { get; set; }
    }

    [WZContract]
    public class CPShopRequestBuy : IGameMessage
    {
        [WZMember(0)] public ushort wzNumber { get; set; }
        [WZMember(1, 10)] public byte[] btName { get; set; }
        [WZMember(2)] public byte Position { get; set; }

        public ushort Number => wzNumber.ShufleEnding();
        public string Name => btName.MakeString();
    }

    [WZContract]
    public class CPShopCloseDeal : IGameMessage
    {
        [WZMember(0)] public ushort wzNumber { get; set; }
        [WZMember(1, 10)] public byte[] btName { get; set; }

        public ushort Number => wzNumber.ShufleEnding();
        public string Name => btName.MakeString();
    }

    [WZContract]
    public class CPartyList : IGameMessage
    {

    }

    [WZContract]
    public class CPartyRequest : IGameMessage
    {
        [WZMember(0)]
        public ushort wzNumber { get; set; }

        public ushort Number { get => wzNumber.ShufleEnding(); set => wzNumber = value.ShufleEnding(); }
    }

    [WZContract]
    public class CPartyRequestResult : IGameMessage
    {
        [WZMember(0)]
        public byte Result { get; set; }

        [WZMember(1)]
        public ushort wzNumber { get; set; }

        public ushort Number { get => wzNumber.ShufleEnding(); set => wzNumber = value.ShufleEnding(); }
    }

    [WZContract]
    public class CPartyDelUser : IGameMessage
    {
        [WZMember(0)]
        public byte Index { get; set; }
    }

    [WZContract]
    public class CDuelRequest : IGameMessage
    {
        [WZMember(0)] public ushort wzNumber { get; set; }
        [WZMember(1, 10)] public byte[] btName { get; set; }

        public CDuelRequest() { }
        public CDuelRequest(ushort number, string name)
        {
            wzNumber = number.ShufleEnding();
            btName = name.GetBytes();
        }
    }

    [WZContract]
    public class CDuelAnswer : IGameMessage
    {
        [WZMember(0)] public byte DuelOK { get; set; }
        [WZMember(1)] public ushort wzNumber { get; set; }

        public ushort Number => wzNumber.ShufleEnding();
    }

    [WZContract]
    public class CDuelLeave : IGameMessage { }

    [WZContract]
    public class CDuelJoinRoom : IGameMessage 
    {
        [WZMember(0)] public byte Room { get; set; }
    }

    [WZContract]
    public class CDuelLeaveRoom : IGameMessage
    {
        [WZMember(0)] public byte Room { get; set; }
    }

    #region Friend
    [WZContract]
    public class CFriendList : IGameMessage { }

    [WZContract]
    public class CFriendAdd : IGameMessage
    {
        [WZMember(0,10)] public byte[] btName { get; set; }

        public string Name => btName.MakeString();
    }
    #endregion

    [WZContract]
    public class CMasterSkill : IGameMessage
    {
        [WZMember(0)]
        public Spell MasterSkill { get; set; }

        [WZMember(1)]
        public ushort MasterEmpty { get; set; }
    }

    [WZContract]
    public class CTradeRequest : IGameMessage
    {
        [WZMember(0)]
        public ushort wzNumber { get; set; }

        public ushort Number { get => wzNumber.ShufleEnding(); }
    }

    [WZContract]
    public class CTradeResponce : IGameMessage
    {
        [WZMember(0)]
        public byte Result { get; set; }

        /*[WZMember(1, 10)]
        public byte[] szId { get; set; }

        [WZMember(2)]
        public ushort Level { get; set; }

        [WZMember(3)]
        public int GuildNumber { get; set; }*/
    }

    [WZContract]
    public class CTradeMoney : IGameMessage
    {
        [WZMember(0)]
        public uint Money { get; set; }
    }

    [WZContract]
    public class CTradeButtonOk : IGameMessage
    {
        [WZMember(0)]
        public byte Flag { get; set; }
    }

    [WZContract]
    public class CTradeButtonCancel : IGameMessage
    { }

    [WZContract]
    public class CFriendAddReq : IGameMessage
    {
        [WZMember(0, 10)] public byte[] btName { get; set; }

        public string Name { get => btName.MakeString(); set => btName = value.GetBytes(); }
    }

    [WZContract]
    public class CWaitFriendAddReq : IGameMessage
    {
        [WZMember(0)] public byte Result { get; set; }

        [WZMember(1, 10)] public byte[] btName { get; set; }

        public string Name { get => btName.MakeString(); set => btName = value.GetBytes(); }
    }

    [WZContract]
    public class CMemberPosInfoStart : IGameMessage
    { }

    [WZContract]
    public class CMemberPosInfoStop : IGameMessage
    { }

    [WZContract]
    public class CNPCJulia : IGameMessage
    { }

    [Flags]
    public enum HuntingFlags19 : byte
    {
        AutoPotion=0x01,
        DrainLife = 0x04,
        LongDistanceC = 0x08,
        OriginalPosition = 0x10,
        UseSkillClosely = 0x20,
        Party = 0x40,
        PreferenceOfParty = 0x80,
    }

    [Flags]
    public enum HuntingFlags1A : byte
    {
        BuffTimeParty = 0x01,
        BuffDuration = 0x04,
        Delay = 0x08,
        Condition = 0x10,
        MonsterAttacking = 0x20,
        Cond1 = 0x40,
        Cond2 = 0x80,
        Cond3 = 0xC0,
    }

    [Flags]
    public enum HuntingFlags1B : byte
    {
        Delay = 0x01,
        Condition = 0x02,
        MonsterAttacking = 0x04,
        Cond1 = 0x08,
        Cond2 = 0x10,
        Cond3 = 0x18,
        Repair = 0x20,
        PickAllNearItems = 0x40,
        PickSelectedItems = 0x80,
    }

    [Flags]
    public enum HuntingFlags1C : byte
    {
        Delay = 0x01,
        Condition = 0x02,
        AutoAcceptFriend = 0x04,
        AutoAcceptGuild = 0x08,
        UseElitePotion = 0x10,
        UseSkillClosely = 0x20,
        UseRegularAttackArea = 0x40,
        PickSelectedItems = 0x80,
    }

    [Flags]
    public enum OptainingFlags:byte
    {
        Unk = 0x01,
        Jewels = 0x08,
        SetItem = 0x10,
        ExcellentItem = 0x20,
        Zen = 0x40,
        ExtraItem = 0x80,
    }

    [WZContract(LongMessage = true)]
    public class CMUBotData : IGameMessage
    {
        /*[WZMember(0, typeof(BinarySerializer), 257)]
        public byte[] Data { get; set; }*/
        [WZMember(0)] public byte Data0 { get; set; }
        [WZMember(1)] public OptainingFlags OptainingFlags { get; set; }
        [WZMember(2)] public byte Data2 { get; set; }
        [WZMember(3)] public byte OPDelayTime { get; set; }
        [WZMember(4)] public ushort BasicSkill { get; set; }
        [WZMember(6)] public ushort ActivationSkill { get; set; }
        [WZMember(8)] public ushort DelayTime { get; set; }
        [WZMember(0xA)] public ushort ActivationSkill2 { get; set; }
        [WZMember(0xC)] public ushort DelayTime2 { get; set; }
        [WZMember(0xE)] public ushort Unk0E { get; set; }
        [WZMember(0x10)] public ushort Buff1 { get; set; }
        [WZMember(0x12)] public ushort Buff2 { get; set; }
        [WZMember(0x14)] public ushort Buff3 { get; set; }
        [WZMember(0x16)] public byte Unk16 { get; set; }
        [WZMember(0x17)] public byte AutoPotion_Heal { get; set; }
        [WZMember(0x18)] public byte AutoDrainLife_Party { get; set; }
        [WZMember(0x19)] public HuntingFlags19 Flags19 { get; set; }
        [WZMember(0x1A)] public HuntingFlags1A Flags1A { get; set; }
        [WZMember(0x1B)] public HuntingFlags1B Flags1B { get; set; }
        [WZMember(0x1C)] public HuntingFlags1C Flags1C { get; set; }
        [WZMember(0x1D, typeof(BinarySerializer), 36)] public byte[] Data1D { get; set; }
        [WZMember(0x41, typeof(BinaryStringSerializer), 16)] public string ExtraItem1 { get; set; }
        [WZMember(0x51, typeof(BinaryStringSerializer), 16)] public string ExtraItem2 { get; set; }
        [WZMember(0x61, typeof(BinaryStringSerializer), 16)] public string ExtraItem3 { get; set; }
        [WZMember(0x71, typeof(BinaryStringSerializer), 16)] public string ExtraItem4 { get; set; }
        [WZMember(0x81, typeof(BinaryStringSerializer), 16)] public string ExtraItem5 { get; set; }
        [WZMember(0x91, typeof(BinaryStringSerializer), 16)] public string ExtraItem6 { get; set; }
        [WZMember(0xA1, typeof(BinaryStringSerializer), 16)] public string ExtraItem7 { get; set; }
        [WZMember(0xB1, typeof(BinaryStringSerializer), 16)] public string ExtraItem8 { get; set; }
        [WZMember(0xC1, typeof(BinaryStringSerializer), 16)] public string ExtraItem9 { get; set; }
        [WZMember(0xD1, typeof(BinaryStringSerializer), 16)] public string ExtraItem10 { get; set; }
        [WZMember(0xE1, typeof(BinaryStringSerializer), 16)] public string ExtraItem11 { get; set; }
        [WZMember(0xF1, typeof(BinaryStringSerializer), 16)] public string ExtraItem12 { get; set; }
        public int AutoDrainLife
        {
            get => AutoDrainLife_Party & 0x0F;
            set
            {
                AutoDrainLife_Party &= 0xF0;
                AutoDrainLife_Party |= (byte)value;
            }
        }
        public int AutoPartyHeal
        {
            get => (AutoDrainLife_Party >> 4) & 0x0F;
            set
            {
                AutoDrainLife_Party &= 0x0F;
                AutoDrainLife_Party |= (byte)(value << 4);
            }
        }
        public int AutoPotion
        {
            get => AutoPotion_Heal & 0x0F;
            set
            {
                AutoPotion_Heal &= 0xF0;
                AutoPotion_Heal |= (byte)value;
            }
        }
        public int AutoHeal
        {
            get => (AutoPotion_Heal >> 4) & 0x0F;
            set
            {
                AutoPotion_Heal &= 0x0F;
                AutoPotion_Heal |= (byte)(value << 4);
            }
        }
        public int HuntingRange
        {
            get => Data2 & 0x0F;
            set
            {
                Data2 &= 0xF0;
                Data2 |= (byte)value;
            }
        }
        public int OptainingRange
        {
            get => (Data2>>4) & 0x0F;
            set
            {
                Data2 &= 0x0F;
                Data2 |= (byte)(value<<4);
            }
        }
    }

    [WZContract]
    public class CMuHelperState : IGameMessage
    {
        [WZMember(0)]
        public byte State { get; set; }
    }

    [WZContract]
    public class CQuestExp : IGameMessage
    { }

    [WZContract]
    public class CShadowBuff : IGameMessage
    { }

    [WZContract]
    public class CGremoryCaseOpen : IGameMessage
    { }

    [WZContract]
    public class CGremoryCaseOpenS16 : IGameMessage
    {
        [WZMember(0)] public byte Unk { get; set; }
    }

    [WZContract]
    public class CGremoryCaseUseItem : IGameMessage
    {
        //Packet C1 11 4F 02 [98 1D] [00 00] [2B 00 00 00] [00 00 00 00] 02
        [WZMember(0)] public ushort Item { get; set; }
        [WZMember(1)] public ushort Unk { get; set; }
        [WZMember(3)] public uint Serial { get; set; }
        [WZMember(4)] public uint Slot { get; set; }
        [WZMember(5)] public GremoryStorage Inventory { get; set; }
    }

    [WZContract]
    public class CAcheronEnterReq : IGameMessage
    { }

    [WZContract]
    public class CRefineJewelReq : IGameMessage
    {
        [WZMember(0)] public byte Type { get; set; }
    }

    [WZContract]
    public class CPentagramaJewelIn : IGameMessage
    {
        [WZMember(0)] public int PentagramPos { get; set; }
        [WZMember(1)] public int JewelPos { get; set; }
    }

    [WZContract]
    public class CPShopSearchItem : IGameMessage
    {
        [WZMember(0)] public int iLastCount { get; set; }
        [WZMember(1)] public short sSearchItem { get; set; }
    }

    [WZContract]
    public class CPetInfo : IGameMessage
    {
        [WZMember(0)] public byte PetType { get; set; }   // 3
        [WZMember(1)] public byte InvenType { get; set; } // 4
        [WZMember(2)] public byte nPos { get; set; }	// 5
    }

    [WZContract]
    public class CPetCommand : IGameMessage
    {
        [WZMember(0)] public byte PetType { get; set; }   // 3
        [WZMember(1)] public PetMode Command { get; set; }   // 4
        [WZMember(2)] public ushort wzNumber { get; set; }   // 5

        public ushort Number { get => wzNumber.ShufleEnding(); set => wzNumber = value.ShufleEnding(); }   // 5
    };

    [WZContract]
    public class CInventoryEquipament : IGameMessage
    {
        [WZMember(0)] public byte ItemPos { get; set; }
        [WZMember(1)] public UseItemFlag Type { get; set; }
    }

    [WZContract]
    public class CSXInfo : IGameMessage
    { }

    [WZContract]
    public class CNewQuest : IGameMessage
    { }

    [WZContract]
    public class CWarehouseMoney : IGameMessage
    {
        //0xC1
        //0x08
        //0x81
        [WZMember(0)] public byte Type { get; set; }
        [WZMember(1)] public uint Money { get; set; }
    }
    [WZContract]
    public class CFavoritesList : IGameMessage
    {
        //0xC1
        //0x1C
        //0x6D,0x01
        [WZMember(1, typeof(ArrayWithScalarSerializer<int>))] public int[] Region { get; set; }
    }

    [WZContract]
    public class COpenBox : IGameMessage
    {
        [WZMember(0)] public byte Slot { get; set; }
        [WZMember(1)] public byte data2 { get; set; }
        [WZMember(2)] public byte type { get; set; }
    }

    [WZContract]
    public class CItemSplit : IGameMessage
    {
        [WZMember(1)] public byte Slot { get; set; }
        [WZMember(2)] public byte Type { get; set; }
        [WZMember(3)] public byte Amount { get; set; }
    }



    [WZContract]
    public class CPartyMRegister : IGameMessage
    {
        [WZMember(0, typeof(BinaryStringSerializer), 41)] public string Text { get; set; }
        [WZMember(1, typeof(BinaryStringSerializer), 5)] public string Password { get; set; }
        [WZMember(2)] public ushort MinLevel { get; set; }
        [WZMember(3)] public ushort MaxLevel { get; set; }
        [WZMember(4)] public bool NeedPassword { get; set; }
        [WZMember(5)] public bool AutAccept { get; set; }
        [WZMember(6)] public bool EnergyElf { get; set; }
        [WZMember(7)] public byte padding { get; set; }
    }
    [WZContract]
    public class CPartyMSearch : IGameMessage
    {
        [WZMember(1)] public uint Page { get; set; }
        [WZMember(2, typeof(BinaryStringSerializer), 11)] public string Search { get; set; }
        [WZMember(3)] public byte Flags { get; set; }
    }
    [WZContract]
    public class CPartyMJoin : IGameMessage
    {
        [WZMember(1, typeof(BinaryStringSerializer), 11)] public string Leader { get; set; }
        [WZMember(2, typeof(BinaryStringSerializer), 5)] public string Password { get; set; }
        [WZMember(3)] public bool NeedsPassword { get; set; }
        [WZMember(4)] public bool Random { get; set; }
        [WZMember(5)] public byte AutomaticHelper { get; set; }
    }
    [WZContract]
    public class CPartyMJoinData : IGameMessage
    {
        [WZMember(1)] public byte Slot { get; set; }
        [WZMember(2)] public byte Type { get; set; }
        [WZMember(3)] public byte Amount { get; set; }
    }
    [WZContract]
    public class CPartyMJoinList : IGameMessage
    { }
    [WZContract]
    public class CPartyMAccept : IGameMessage
    {
        [WZMember(0, typeof(BinaryStringSerializer), 11)] public string Applicant { get; set; }
        [WZMember(1)] public bool Accept { get; set; }
    }
    [WZContract]
    public class CPartyMCancel : IGameMessage
    {
        [WZMember(1)] public byte Type { get; set; }
    }
    [WZContract]
    public class CPartyLeaderChange : IGameMessage
    {
        [WZMember(1)] public byte Slot { get; set; }
        [WZMember(2)] public byte Type { get; set; }
        [WZMember(3)] public byte Amount { get; set; }
    }

    [WZContract]
    public class CHuntingRecordRequest : IGameMessage
    {
        [WZMember(1)] public byte Map { get; set; }
        [WZMember(2)] public ushort index { get; set; }
        [WZMember(3)] public ushort unk { get; set; }
    }

    [WZContract]
    public class CHuntingRecordClose : IGameMessage
    { }

    [WZContract]
    public class CHuntingRecordVisibility : IGameMessage
    {
        [WZMember(1)] public byte Visible { get; set; }
    }

    [WZContract]
    public class CMossMerchantOpenBox : IGameMessage
    {
        [WZMember(0)] public byte Section {get; set;}
    }

    [WZContract]
    public class CChangeSkin : IGameMessage
    {
        [WZMember(0)] public byte Skin { get; set; }
    }

    [WZContract]
    public class CRuudBuy : IGameMessage
    {
        [WZMember(0)] public byte Slot { get; set; }
    }

    [WZContract]
    public class CHelperSettingSave : IGameMessage
    {
        [WZMember(0)] public int ItemPickFlag { get; set; }
        [WZMember(1)] public int HuntingRange { get; set; }
        [WZMember(2)] public int Distance { get; set; }
        [WZMember(3)] public int AttackSkill1 { get; set; }
        [WZMember(4)] public int AttackSecSkill1 { get; set; }
        [WZMember(5)] public int AttackSecSkill2 { get; set; }
        [WZMember(6)] public int AttackSecDelay1 { get; set; }
        [WZMember(7)] public int AttackSecDelay2 { get; set; }
        [WZMember(8)] public int TimeSpaceCasting { get; set; }
        [WZMember(9)] public int BuffSkill1 { get; set; }
        [WZMember(10)] public int BuffSkill2 { get; set; }
        [WZMember(11)] public int BuffSkill3 { get; set; }
        [WZMember(12)] public int PercentAutoPot { get; set; }
        [WZMember(13)] public int PercentAutoHeal { get; set; }
        [WZMember(14)] public int PercentDrainLife { get; set; }
        [WZMember(15)] public int PercentAutoPartyHeal { get; set; }
        [WZMember(16)] public int OptionFlag1 { get; set; }
        [WZMember(17)] public int OptionFlag2 { get; set; }
        [WZMember(18)] public string PickItemList { get; set; }
        [WZMember(19)] public int BuffItem1 { get; set; }
        [WZMember(20)] public int BuffItem2 { get; set; }
        [WZMember(21)] public int BuffItem3 { get; set; }
    }
}
