public static class UnitString 
{
    #region Properties

    #region Class

    public static string Archer = "Cung Thủ";
    public static string Cavalry = "Hãm Trận";
    public static string Infantry = "Bộ Binh";
    #endregion

    #region Faction
    public static string VietNam = "Tây Lương";
    public static string MongNguyen = "Đổng Quân";
    public static string Champa = "Thục Hán";
    #endregion

    #region Unit Name
    public static string BuiKham = "Bàng Đức";
    public static string DaTuong = "Diêm Hành";
    public static string YetKieu = "Mã Siêu";

    public static string TruongHanSieu = "Lưu Bị";
    public static string PhamNguLao = "Quan Vũ";
    public static string HaBong = "Trương Phi";

    public static string NgotLuongHopThai = "Đổng Trác";
    public static string KhoanTriet = "Trương Liêu";
    public static string OMaNhi = "Lữ Bố";
    public static string ToaDo = "Giả Hủ";
    public static string LyHang = "Lý Nho";
    public static string ThoatHoan = "Hoa Hùng";

    #endregion

    #region LoginManager

    public static string rulePlayerName_Error = "Tên không hợp lệ \n" +
        "Tên nhân vật phải từ 3 tới 14 ký tự \n" +
        "Vui lòng không sử dụng ký tự đặc biệt";

    #endregion
    
    #endregion

    #region Methods
    public static string GetClassString(UnitClass unitClass)
    {
        switch (unitClass)
        {
            case UnitClass.Archer:
                return Archer;
            case UnitClass.Cavalry:
                return Cavalry;
            case UnitClass.Infantry:
                return Infantry;
            case UnitClass.Mandarin:
                return Infantry;
            case UnitClass.Marine:
                return Infantry;
            case UnitClass.Partisans:
                return Infantry;
            case UnitClass.RoyalGuard:
                return Infantry;
            case UnitClass.WarElephant:
                return Infantry;
            default:
                return Infantry;
        }
    }

    public static string GetFactionString(UnitFaction unitFaction)
    {
        switch (unitFaction)
        {
            case UnitFaction.VietNam:
                return VietNam;
            case UnitFaction.MongNguyen:
                return MongNguyen;
            case UnitFaction.Khmer:
                return Champa;
            case UnitFaction.Champa:
                return Champa;
            case UnitFaction.VietRoyal:
                return Champa;
            case UnitFaction.Thai:
                return Champa;
            case UnitFaction.Tay:
                return Champa;
            default:
                return Champa;
        }
    }
    #endregion
}
