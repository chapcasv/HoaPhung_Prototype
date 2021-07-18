using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeverGame : MonoBehaviour
{
    public void Create_game_data()
    {
        Game_Database game_data = new Game_Database();
        game_data.list_raid = create_List_raid();
        game_data.units = Create_ListUnit();
        Save_System.Save_Game_Data(game_data);
    }

    #region Unit Database
    private List<Unit> Create_ListUnit()
    {
        List<Unit> list_Unit = new List<Unit>();
        list_Unit.Add(BuiKham());
        list_Unit.Add(DaTuong());
        list_Unit.Add(YetKieu());


        list_Unit.Add(LyHang());
        list_Unit.Add(NgotLuongHopThai());
        list_Unit.Add(ThoatHoan());
        list_Unit.Add(OMaNhi());
        list_Unit.Add(ToaDo());
        list_Unit.Add(KhoanTriet());

        list_Unit.Add(HaBong());
        list_Unit.Add(PhamNguLao());
        list_Unit.Add(TruongHanSieu());

        return list_Unit;
    }

    #region Hero Database

    private Unit BuiKham()
    {
        Unit unit = new Unit();
        unit.ID = "H001";
        unit.Unit_name = UnitString.BuiKham;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitClass = UnitClass.Cavalry;
        unit.unitFaction = UnitFaction.VietNam;
        
        unit.HP = 650;
        unit.Int = 0;
        unit.Str = 40;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.65f;
        unit.SP_max = 40;
        unit.SP_current = 25;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 1;
        unit.Range = 1;

        return unit;
    }   
    private Unit LyHang()
    {
        Unit unit = new Unit();
        unit.ID = "H002";
        unit.Unit_name = UnitString.LyHang;
        unit.description = "";
        unit.talent_name = "Túi Khôn Thiên Hạ";
        unit.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Hậu Kế";
        unit.skill_description = "Gây sát thương bằng 300% /390% /450% trí tuệ, /n " +
            "tạo giáp ảo cho 2/3/3 đồng minh bên cạnh mục tiêu" +
            " lượng giáp ảo tương đương 100%/250%/450% trí tuệ";

        unit.unitFaction = UnitFaction.MongNguyen;
        unit.unitClass = UnitClass.Archer;

        unit.HP = 500;
        unit.Int = 100;
        unit.Str = 45;
        unit.HP_perLv = 80;
        unit.Int_perLv = 20;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.65f;
        unit.SP_max = 70;
        unit.SP_current = 30;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 2;
        unit.Range = 3;
        unit.Speed_Projectile = 2f;

        return unit;
    }
    private Unit HaBong()
    {
        Unit bangduc = new Unit();
        bangduc.ID = "H003";
        bangduc.Unit_name = UnitString.HaBong;
        bangduc.description = "";
        bangduc.talent_name = "Hãm Trận Tây Lương";
        bangduc.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        bangduc.skill_name = "Trí Dũng Nho Tướng";
        bangduc.skill_description = "Tạo trận phòng thủ trong 4s, giảm 65% /70% /85% sát thương nhận phải, \n " +
            "gây sát thương về phía trước bằng 100%/120%/150% sức mạnh \n" +
            "hồi phục thể lực mỗi giây tương đương 50% trí tuệ/70% trí tuệ/100% trí tuệ";

        bangduc.unitFaction = UnitFaction.Champa;
        bangduc.unitClass = UnitClass.Infantry;

        bangduc.HP = 850;
        bangduc.Int = 100;
        bangduc.Str = 75;
        bangduc.HP_perLv = 140;
        bangduc.Int_perLv = 15;
        bangduc.Str_perLv = 15;
        bangduc.Atk_Speed = 0.75f;
        bangduc.SP_max = 60;
        bangduc.SP_current = 30;
        bangduc.Have_SP_bar = true;
        bangduc.Have_Stack_bar = false;
        bangduc.Cost = 2;
        bangduc.Range = 1;

        return bangduc;
    }
    private Unit NgotLuongHopThai()
    {
        Unit unit = new Unit();
        unit.ID = "H004";
        unit.Unit_name = UnitString.NgotLuongHopThai;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitFaction = UnitFaction.MongNguyen;
        unit.unitClass = UnitClass.Archer;

        unit.HP = 900;
        unit.Int = 200;
        unit.Str = 120;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.75f;
        unit.SP_max = 80;
        unit.SP_current = 50;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 3;
        unit.Range = 4;
        unit.Speed_Projectile = 1.5f;
        return unit;
    }
    private Unit ThoatHoan()
    {
        Unit unit = new Unit();
        unit.ID = "H005";
        unit.Unit_name = UnitString.ThoatHoan;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitFaction = UnitFaction.MongNguyen;
        unit.unitClass = UnitClass.Cavalry;

        unit.HP = 700;
        unit.Int = 0;
        unit.Str = 50;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.75f;
        unit.SP_max = 80;
        unit.SP_current = 50;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 1;
        unit.Range = 1;

        return unit;
    }
    private Unit ToaDo()
    {
        Unit unit = new Unit();
        unit.ID = "H007";
        unit.Unit_name = UnitString.ToaDo;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitFaction = UnitFaction.MongNguyen;
        unit.unitClass = UnitClass.Archer;

        unit.HP = 900;
        unit.Int = 0;
        unit.Str = 120;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.75f;
        unit.SP_max = 80;
        unit.SP_current = 50;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 3;
        unit.Range = 4;
        unit.Speed_Projectile = 3f;

        return unit;
    }
    private Unit OMaNhi()
    {
        Unit unit = new Unit();
        unit.ID = "H008";
        unit.Unit_name = UnitString.OMaNhi;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitFaction = UnitFaction.MongNguyen;
        unit.unitClass = UnitClass.Cavalry;

        unit.HP = 900;
        unit.Int = 0;
        unit.Str = 120;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.75f;
        unit.SP_max = 80;
        unit.SP_current = 50;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 3;
        unit.Range = 1;

        return unit;
    }
    private Unit PhamNguLao()
    {
        Unit unit = new Unit();
        unit.ID = "H009";
        unit.Unit_name = UnitString.PhamNguLao;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitFaction = UnitFaction.Champa;
        unit.unitClass = UnitClass.Infantry;

        unit.HP = 900;
        unit.Int = 0;
        unit.Str = 120;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.75f;
        unit.SP_max = 80;
        unit.SP_current = 50;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 2;
        unit.Range = 1;

        return unit;
    }
    private Unit TruongHanSieu()
    {
        Unit unit = new Unit();
        unit.ID = "H011";
        unit.Unit_name = UnitString.TruongHanSieu;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitFaction = UnitFaction.Champa;
        unit.unitClass = UnitClass.Archer;

        unit.HP = 900;
        unit.Int = 0;
        unit.Str = 120;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.75f;
        unit.SP_max = 80;
        unit.SP_current = 50;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 3;
        unit.Range = 4;

        return unit;
    }
    private Unit DaTuong()
    {
        Unit unit = new Unit();
        unit.ID = "H010";
        unit.Unit_name = UnitString.DaTuong;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Bàng Đức \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitClass = UnitClass.Cavalry;
        unit.unitFaction = UnitFaction.VietNam;
        
        unit.HP = 650;
        unit.Int = 0;
        unit.Str = 50;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.65f;
        unit.SP_max = 50;
        unit.SP_current = 40;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 1;
        unit.Range = 1;

        return unit;
    }
    private Unit KhoanTriet()
    {
        Unit unit = new Unit();
        unit.ID = "H012";
        unit.Unit_name = UnitString.KhoanTriet;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Diêm Hành \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Mã Siêu, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitFaction = UnitFaction.MongNguyen;
        unit.unitClass = UnitClass.Cavalry;

        unit.HP = 900;
        unit.Int = 0;
        unit.Str = 120;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.75f;
        unit.SP_max = 80;
        unit.SP_current = 50;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 2;
        unit.Range = 1;

        return unit;
    }
    private Unit YetKieu()
    {
        Unit unit = new Unit();
        unit.ID = "H073";
        unit.Unit_name = UnitString.YetKieu;
        unit.description = "";
        unit.talent_name = "Hãm Trận Tây Lương";
        unit.talent_description = "Nếu trong trận có Bàng Đức \n " +
            "Gia tăng thêm tốc độ di chuyển, 20 % thể lực gốc và + 30 sức mạnh \n " +
            "Nếu có Bàng Đức, gia tăng 20 % thể lực gốc và 60 sức mạnh";
        unit.skill_name = "Cự Thiết Thương";
        unit.skill_description = "Dùng cự thương tấn công kẻ địch, gây sát thương bằng 260% /290% /360% sức mạnh, /n " +
            "hồi phục thể lực bằng 200/ 300/ 450";

        unit.unitFaction = UnitFaction.VietNam;
        unit.unitClass = UnitClass.Cavalry;

        unit.HP = 1050;
        unit.Int = 0;
        unit.Str = 110;
        unit.HP_perLv = 120;
        unit.Int_perLv = 0;
        unit.Str_perLv = 10;
        unit.Atk_Speed = 0.75f;
        unit.SP_max = 40;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Cost = 2;
        unit.Range = 2;

        return unit;
    }
    #endregion
    private Unit Linh_khan_vang_Dao()
    {
        Unit unit = new Unit();

        unit.ID = "E001";
        unit.Unit_name = "Thanh Châu Binh - Đại Đao";
        unit.HP = 320;
        unit.Int = 10;
        unit.Str = 30;
        unit.Range = 1;
        unit.SP_max = 0;
        unit.SP_regen = 0;
        unit.Atk_Speed = 0.55f;
        unit.unitClass = UnitClass.Infantry;
        unit.unitFaction = UnitFaction.VietNam;
        unit.Position = 1;
        unit.Have_SP_bar = false;
        unit.Have_Stack_bar = false;
        unit.Level = 1;

        return unit;
    }

    private Unit Linh_khan_vang_Cung()
    {
        Unit unit = new Unit();

        unit.ID = "E002";
        unit.Unit_name = "Thanh Châu Binh - Tiễn Thủ";
        unit.HP = 270;
        unit.Int = 40;
        unit.Str = 25;
        unit.Range = 3;
        unit.SP_max = 0;
        unit.SP_regen = 0;
        unit.Atk_Speed = 0.6f;
        unit.unitFaction = UnitFaction.Champa;
        unit.unitClass = UnitClass.Archer;
        unit.Speed_Projectile = 4f;
        unit.Position = 1;
        unit.Have_SP_bar = false;
        unit.Have_Stack_bar = false;
        unit.Level = 1;

        return unit;
    }

    private Unit Linh_khan_vang_Boss()
    {
        Unit unit = new Unit();

        unit.ID = "E003";
        unit.Unit_name = "Thanh Châu Binh - Đầu Mục";
        unit.HP = 600;
        unit.Int = 0;
        unit.Str = 90;
        unit.Range = 1;
        unit.SP_max = 50;
        unit.SP_regen = 5;
        unit.Atk_Speed = 0.7f;
        unit.unitClass = UnitClass.Cavalry;
        unit.unitFaction = UnitFaction.MongNguyen;
        unit.Position = 1;
        unit.Have_SP_bar = true;
        unit.Have_Stack_bar = false;
        unit.Level = 2;

        return unit;
    }

    #endregion


    #region Raid Database
    private List<Raid> create_List_raid()
    {
        List<Raid> list_raid = new List<Raid>(); 
        list_raid.Add(Training());
        list_raid.Add(Raid_Tutorial());
        return list_raid;
    }


    #region Training - Tutorial

    private Raid Training()
    {
        Raid Training = new Raid();
        Training.id = "R000";
        Training.Raid_name = "Tập luyện";
        Training.raid_stage = new List<RaidStage> { 
            Training_Room_1(),
            Training_Room_2()};
        return Training;
    }
    private RaidStage Training_Room_1()
    {
        RaidStage stage = new RaidStage();
        stage.stage_name = "Tập luyện 01";
        stage.id = "S099";
        stage.ID_avatar = "E001";
        stage.stage_discription = "Tập luyện";
        stage.NPC_ID = new List<string>();
        stage.battles = new List<Battle>() { Battle_Training_Room_1() };
        return stage;
    }
    private Battle Battle_Training_Room_1()
    {
        Battle battle = new Battle();
        battle.enemy = new List<Unit>();

        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy[0].Position = 45;
        battle.enemy[0].Str = 1;
        battle.enemy[0].HP = 10000;
        battle.enemy[1].Position = 58;
        battle.enemy[1].Range = 6;
        battle.enemy[1].Str = 1;
        battle.enemy[1].HP = 10000;
        battle.enemy[2].Position = 63;
        battle.enemy[2].Range = 5;
        battle.enemy[2].Str = 1;
        battle.maxAmount = 9;

        return battle;
    }
    private RaidStage Training_Room_2()
    {
        RaidStage stage = new RaidStage();
        stage.stage_name = "Tập luyện 02";
        stage.id = "S098";
        stage.ID_avatar = "E002";
        stage.stage_discription = "Tập luyện";
        stage.NPC_ID = new List<string>();
        stage.battles = new List<Battle>() { Battle_Training_Room_2() };
        return stage;
    }
    private Battle Battle_Training_Room_2()
    {
        Battle battle = new Battle();
        battle.enemy = new List<Unit>() { Linh_khan_vang_Dao() };
        battle.enemy[0].Position = 37;
        battle.enemy[0].Str = 1;
        battle.enemy[0].HP = 10000;
        battle.enemy[0].Range = 5;
        battle.enemy[0].unitClass = UnitClass.Archer;
        battle.maxAmount = 9;

        return battle;
    }
    private Raid Raid_Tutorial()
    {
        Raid loan_khan_vang = new Raid();
        loan_khan_vang.id = "R001";
        loan_khan_vang.Raid_name = "Ải Mở Đầu";

        loan_khan_vang.raid_stage = new List<RaidStage> {
            Stage_Tutorial()
        };

        return loan_khan_vang;
    }

    

    private RaidStage Stage_Tutorial()
    {
        RaidStage stage = new RaidStage();
        stage.stage_name = "Khăn Vàng 1";
        stage.id = "S001";
        stage.ID_avatar = "E001";
        stage.stage_discription = "Đào binh khỏi quân ngũ, chuyển làm thổ phỉ";
        stage.NPC_ID = new List<string>();
        stage.battles = new List<Battle>() {Tutorial_Battle_1(), Tutorial_Battle_2(), Tutorial_Battle_3(),
        Tutorial_Battle_4()};
        //, Tutorial_Battle_6()
        //Tutorial_Battle_5()
        return stage;
    }

    private Battle Tutorial_Battle_1()
    {
        Battle battle = new Battle();
        battle.enemy = new List<Unit>();

        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Cung());

        battle.enemy[0].Position = 36;
        battle.enemy[1].Position = 63;
        battle.maxAmount = 1;
        battle.maxTimeBattle = 30f;

        return battle;
    }

    private Battle Tutorial_Battle_2()
    {
        Battle battle = new Battle();
        battle.enemy = new List<Unit>();

        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Cung());

        battle.enemy[0].Position = 37;
        battle.enemy[1].Position = 38;
        battle.enemy[2].Position = 60;
        battle.maxAmount = 2;
        battle.maxTimeBattle = 40f;

        return battle;
    }

    private Battle Tutorial_Battle_3()
    {
        Battle battle = new Battle();
        battle.enemy = new List<Unit>();

        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Cung());
        battle.enemy.Add(Linh_khan_vang_Dao());
        //battle.enemy.Add(Linh_khan_vang_Dao());

        battle.enemy[0].Position = 36;
        battle.enemy[1].Position = 37;
        battle.enemy[2].Position = 61;
        battle.enemy[3].Position = 39;
        //battle.enemy[4].Position = 41;

        battle.maxAmount = 3;
        battle.maxTimeBattle = 50f;
        return battle;
    }

    private Battle Tutorial_Battle_4()
    {
        Battle battle = new Battle();
        battle.enemy = new List<Unit>();

        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Cung());
        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Cung());
        battle.enemy.Add(Linh_khan_vang_Boss());
        battle.enemy.Add(Linh_khan_vang_Boss());

        battle.enemy[0].Position = 34;
        battle.enemy[1].Position = 36;
        battle.enemy[2].Position = 60;
        battle.enemy[3].Position = 38;
        battle.enemy[4].Position = 61;
        battle.enemy[5].Position = 40;
        battle.enemy[6].Position = 39;

        battle.maxAmount = 4;
        battle.maxTimeBattle = 50f;
        return battle;
    }

    private Battle Tutorial_Battle_5()
    {
        Battle battle = new Battle();
        battle.enemy = new List<Unit>();

        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Boss());
        battle.enemy.Add(Linh_khan_vang_Cung());
        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Cung());
        battle.enemy.Add(Linh_khan_vang_Boss());
        battle.enemy.Add(Linh_khan_vang_Boss()); 

        battle.enemy[0].Position = 35;
        battle.enemy[1].Position = 50;
        battle.enemy[2].Position = 60;
        battle.enemy[3].Position = 38;
        battle.enemy[4].Position = 61;
        battle.enemy[5].Position = 52;
        battle.enemy[6].Position = 40;
        battle.maxAmount = 6;

        return battle;
    }

    private Battle Tutorial_Battle_6()
    {
        Battle battle = new Battle();

        battle.enemy = new List<Unit>();

        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Boss());
        battle.enemy.Add(Linh_khan_vang_Cung());
        battle.enemy.Add(Linh_khan_vang_Dao());
        battle.enemy.Add(Linh_khan_vang_Cung());
        battle.enemy.Add(Linh_khan_vang_Boss());
        battle.enemy.Add(Linh_khan_vang_Cung());
        battle.enemy.Add(Linh_khan_vang_Boss());
        battle.enemy.Add(Linh_khan_vang_Boss());

        battle.enemy[0].Position = 4;
        battle.enemy[1].Position = 13;
        battle.enemy[2].Position = 7;
        battle.enemy[3].Position = 20;
        battle.enemy[4].Position = 23;
        battle.enemy[5].Position = 28;
        battle.enemy[6].Position = 31;
        battle.enemy[7].Position = 52;
        battle.enemy[8].Position = 60;
        battle.maxAmount = 9;

        return battle;
    }

    #endregion

    

    #endregion
}


