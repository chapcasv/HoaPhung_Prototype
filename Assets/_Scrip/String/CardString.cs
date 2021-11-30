public static class CardString 
{
    #region Properties

    #region Class

    public static string DontHaveUnitClass = "@@@@@@@@@";
    public static string Hunter = "Thợ Săn";
    public static string Cavalry = "Cưỡi Thú";
    public static string Warrior = "Chiến Binh";
    #endregion

    #region Faction

    public static string DontHaveUnitFaction = "@@@@@@@@@";
    public static string Water = "Thủy Tộc";
    public static string RockMountain = "Tản Viên";
    public static string Beast = "Dã Thú";
    public static string GodDragon = "Thần Long";
    #endregion


    #region Item Name

    #region BrokenSworld
    public static readonly string BrokenSworld = "Tàn Kiếm";
    public static readonly string BrokenSworld_Description = "Vũ khí tinh luyện thô, trải qua nhiều trận chiến đã bị mài mòn";

    #endregion
    #endregion
    #endregion

    #region Methods
    public static string GetClassString(UnitClass unitClass)
    {
        switch (unitClass)
        {
            case UnitClass.DontHaveClass:
                return DontHaveUnitClass;
            case UnitClass.Hunter:
                return Hunter;
            case UnitClass.Cavalry:
                return Cavalry;
            case UnitClass.Warrior:
                return Warrior;
            default:
                return DontHaveUnitClass;
        }
    }

    public static string GetFactionString(UnitFaction unitFaction)
    {
        switch (unitFaction)
        {
            case UnitFaction.DontHaveFaction:
                return DontHaveUnitFaction;
            case UnitFaction.Water:
                return Water;
            case UnitFaction.RockMountain:
                return RockMountain;
            case UnitFaction.Beast:
                return Beast;
            case UnitFaction.GodDragon:
                return GodDragon;
            default:
                return DontHaveUnitFaction;
        }
    }
    #endregion
}
