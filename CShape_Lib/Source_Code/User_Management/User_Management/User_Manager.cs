using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;
using EFC.INI;
using EFC.Tool;
using EFC.Reader;


namespace EFC.User_Manager
{
    public class User_Manager
    {
        public TUser_Info              User = new TUser_Info();
        public TUser_List              User_List = new TUser_List();
        private System.Timers.Timer    Logout_Timer = new System.Timers.Timer();
        private TBase_Reader[]         Readers = new TBase_Reader[0];
        public bool                    RFID_Login = true;
        public bool                    Reflash_Flag = false;
        public TLog                    Log = null;
        protected TLog_Message         Default_Msg = new TLog_Message("User_Manager", "");
        public evComRead_Code          On_Reader_Read = null;

        public User_Manager()
        {
            User.Set("0000-0001", "操作員", "", 0, emUser_Info_Type.User, true);
            Logout_Time = 5;
            Logout_Timer.Elapsed += On_Timeout;
            Auto_Logout_Out = true;
        }
        public void Copy(User_Manager sor, ref User_Manager dis)
        {
            dis.User = sor.User.Copy();
            dis.User_List.Set(sor.User_List);
            dis.Logout_Timer.Interval = sor.Logout_Timer.Interval;

            Array.Resize(ref dis.Readers, 0);
            for (int i = 0; i < Readers.Length; i++)
                dis.Add_Reader(sor.Readers[i]);
            dis.Reflash_Flag = sor.Reflash_Flag;
            dis.Log = sor.Log;
        }
        public void Copy(ref User_Manager dis)
        {
            Copy(this, ref dis);
        }
        public User_Manager Copy()
        {
            User_Manager result = new User_Manager();
            Copy(this, ref result);
            return result;
        }

        public void Add_Reader(TBase_Reader reader)
        {
            int count = Readers.Length;

            Array.Resize(ref Readers, count + 1);
            Readers[count] = reader;
            Readers[count].On_Read_Code += RFID_Read;
        }
        
        
        public bool Auto_Logout_Out
        {
            get
            {
                return Logout_Timer.Enabled;
            }
            set
            {
                Logout_Timer.Enabled = value;
            }
        }
        public int Logout_Time
        {
            get
            {
                return (int)Math.Round(Logout_Timer.Interval / 1000 / 60, 0);
            }
            set
            {
                Logout_Timer.Interval = value * 1000 * 60;
            }
        }
        public void Create_Table(string file_name)
        {
            User_List.Clear();
            User_List.Add(new TUser_Info("0000-0001", "操作员", "", 0, emUser_Info_Type.User, true));
            User_List.Add(new TUser_Info("0000-0002", "工程师", "0000", 1, emUser_Info_Type.User, true));
            User_List.Add(new TUser_Info("0000-0003", "管理者", "0000", 2, emUser_Info_Type.User, true));
            User_List.Add(new TUser_Info("0000-0004", "制造商", "22994919", 9, emUser_Info_Type.User, false));
            User_List.Add(new TUser_Info("0000-0005", "原厂", "22994919", 9, emUser_Info_Type.User, false));
            User_List.Write_File(file_name);
        }
        public ArrayList Get_Name_List()
        {
            ArrayList result = new ArrayList();

            for (int i = 0; i < User_List.Count; i++)
            {
                if (User_List[i].Display) result.Add(User_List[i].Name);
            }
            return result;
        }
        public bool Login(string name, string password)
        {
            bool result = false;
            TUser_Info tmp_user = User_List[User_List.IndexOf_Name(name)];
            if (tmp_user != null && tmp_user.Password == password)
            {
                User = tmp_user.Copy();
                Reflash_Flag = true;
                Log_User_Login(User);
                result = true;
            }
            else
            {
                MessageBox.Show("密碼錯誤", "Error", MessageBoxButtons.OK);
            }
            return result;
        }
        public bool Login(string id)
        {
            bool result = false;
            TUser_Info tmp_user = User_List[User_List.IndexOf_ID(id)];

            if (tmp_user != null)
            {
                if (tmp_user.Password != "")
                {
                    Logout();
                    if (Login_Form_User_RFID(tmp_user))
                    {
                        tmp_user.Copy(User);
                    }
                }
                else
                {
                    tmp_user.Copy(User);
                    Reflash_Flag = true;
                    Log_User_Login(User);
                }
                result = true;
            }
            else
            {
                MessageBox.Show("ID錯誤", "Error", MessageBoxButtons.OK);
            }
            return result;
        }
        public bool Login_Form_User(TUser_Info user)
        {
            bool result = false;
            TForm_User_Login form = new TForm_User_Login(this, user);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.User.Copy(user);
                result = true;
            }
            return result;
        }
        public bool Login_Form_User_RFID(TUser_Info user)
        {
            bool result = false;
            TForm_RFID_Login form = new TForm_RFID_Login(this, user);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.User.Copy(user);
                result = true;
            }
            return result;
        }
        public void Logout()
        {
            Log_User_Logout(User);
            User.Name = "操作員";
            User.Level = 0;
            Reflash_Flag = true;
        }
        public void RFID_Read(object sender, string code)
        {
            if (On_Reader_Read != null) On_Reader_Read(sender, code);
            if (RFID_Login)
            {
                Login(code);
            }
        }

        public void Log_Add(string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(Default_Msg.Source, Default_Msg.Fun, "[User_Manager]" + msg_str, type);
        }
        public void Log_Add(TLog_Message msg, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(msg, "[User_Manager]" + msg_str, type);
        }
        public void Log_Add(string source, string fun, string msg_str, emLog_Type type = emLog_Type.Generally)
        {
            if (Log != null) Log.Add(source, fun, "[User_Manager]" + msg_str, type);
        }

        public void Log_User_Login(TUser_Info user)
        {
            Log_Add("User_Manager", "Log_User_Login", string.Format("使用者登入 ID={0:s} , Name = {1:s}", user.ID, user.Name));
        }
        public void Log_User_Logout(TUser_Info user)
        {
            Log_Add("User_Manager", "Log_User_Logout", string.Format("使用者登出 ID={0:s} , Name = {1:s}", user.ID, user.Name));
        }
        public bool User_Change_Password(ref TUser_Info user)
        {
            bool result = false;

            TForm_Change_Password form = new TForm_Change_Password(user);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(user);

                TUser_Info tmp_user = User_List[user.ID];
                if (tmp_user != null)
                {
                    tmp_user.Set(form.Param);
                    Log_Add("User_Manager", "User_Change_Password", string.Format("使用者 ID={0:s} Name={1:s} 密碼變更。", tmp_user.ID, tmp_user.Name));
                    User_List.Write();
                }
                result = true;
            }
            return result;
        }
        public bool User_Table_Edit()
        {
            bool result = false;
            TForm_User_Table_Edit form = new TForm_User_Table_Edit(this);
            if (form.ShowDialog() == DialogResult.OK)
            {
                User_Manager tmp = this;
                User_List.Set(form.User_List);
                User_List.Write();
                result = true;
            }
            return result;
        }
        public bool User_Add(TUser_List user_list, ref TUser_Info user)
        {
            bool result = false;
            TForm_Uset_Edit form = new TForm_Uset_Edit(this, user_list, user, emForm_Mode.Add, emUser_Info_Type.User);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(user);
                result = true;
            }
            return result;
        }
        public bool User_RFID_Add(TUser_List user_list, ref TUser_Info user)
        {
            bool result = false;
            TForm_Uset_Edit form = new TForm_Uset_Edit(this, user_list, user, emForm_Mode.Add, emUser_Info_Type.RFID);
            form.E_ID.Enabled = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(user);
                result = true;
            }
            return result;
        }
        public bool User_Edit(TUser_List user_list, ref TUser_Info user)
        {
            bool result = false;
            TForm_Uset_Edit form = new TForm_Uset_Edit(this, user_list, user, emForm_Mode.Edit, emUser_Info_Type.User);
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(user);
                result = true;
            }
            return result;
        }
        public bool User_RFID_Edit(TUser_List user_list, ref TUser_Info user)
        {
            bool result = false;
            TForm_Uset_Edit form = new TForm_Uset_Edit(this, user_list, user, emForm_Mode.Edit, emUser_Info_Type.RFID);
            form.E_ID.Enabled = false;
            if (form.ShowDialog() == DialogResult.OK)
            {
                form.Param.Copy(user);
                result = true;
            }
            return result;
        }

        private void Add_Table_Columns(DataTable table)
        {
            table.Columns.Clear();
            table.Columns.Add(TUser_Info.TableName_ID, typeof(string));
            table.Columns.Add(TUser_Info.TableName_Name, typeof(string));
            table.Columns.Add(TUser_Info.TableName_Password, typeof(string));
            table.Columns.Add(TUser_Info.TableName_Level, typeof(int));
        }
        private void On_Timeout(object sender, EventArgs e)
        {
            Logout_Timer.Enabled = false;
            Logout();
        }
        
    }
    public class TUser_Info
    {
        public string ID = "";
        public string Name = "";
        public string Password = "";
        public bool Display = true;
        public emUser_Info_Type Type = emUser_Info_Type.User;
        public string Info = "";
        public int Level = 0;
        static public byte[] key = Encoding.ASCII.GetBytes("12345678");
        static public byte[] iv = Encoding.ASCII.GetBytes("87654321");

        static public string TableName_ID
        {
            get
            {
                return "ID";
            }
        }
        static public string TableName_Name
        {
            get
            {
                return "Name";
            }
        }
        static public string TableName_Password
        {
            get
            {
                return "Password";
            }
        }
        static public string TableName_Display
        {
            get
            {
                return "Display";
            }
        }
        static public string TableName_Type
        {
            get
            {
                return "Type";
            }
        }
        static public string TableName_Level
        {
            get
            {
                return "Level";
            }
        }
        public int Type_Int
        {
            get
            {
                int result = 0;
                switch(Type)
                {
                    case emUser_Info_Type.User: result = 0; break;
                    case emUser_Info_Type.RFID: result = 1; break;
                }
                return result;
            }
            set
            {
                switch (value)
                {
                    case 0: Type = emUser_Info_Type.User; break;
                    case 1: Type = emUser_Info_Type.RFID; break;
                }
            }
        }
        public string Type_String
        {
            get
            {
                string result = "User";
                switch (Type)
                {
                    case emUser_Info_Type.User: result = "User"; break;
                    case emUser_Info_Type.RFID: result = "RFID"; break;
                }
                return result;
            }
            set
            {
                switch (value)
                {
                    case "User": Type = emUser_Info_Type.User; break;
                    case "RFID": Type = emUser_Info_Type.RFID; break;
                }
            }
        }
        public TUser_Info()
        {

        }
        public TUser_Info(string id, string name)
        {
            Set(id, name);
        }
        public TUser_Info(string id, string name, string Password, int level, emUser_Info_Type type, bool display)
        {
            Set(id, name, Password, level, type, display);
        }
        public void Copy(TUser_Info sor, TUser_Info dis)
        {
            dis.ID = sor.ID;
            dis.Name = sor.Name;
            dis.Level = sor.Level;
            dis.Password = sor.Password;
            dis.Type = sor.Type;
            dis.Display = sor.Display;
        }
        public void Copy(TUser_Info dis)
        {
            Copy(this, dis);
        }
        public TUser_Info Copy()
        {
            TUser_Info result = new TUser_Info();

            Copy(this, result);
            return result;
        }
        public void Set(TUser_Info sor)
        {
            Copy(sor, this);
        }

        public void Set(string id, string name)
        {
            ID = id;
            Name = name;
        }
        public void Set(string id, string name, string password, int level, emUser_Info_Type type, bool display)
        {
            ID = id;
            Name = name;
            Password = password;
            Level = level;
            Type = type;
            Display = display;
        }
        public bool Read(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ID = ini.ReadString(section, "ID", "");
                Name = ini.ReadString(section, "Name", "");
                Password = Decode(ini.ReadString(section, "Password", ""));
                Info = ini.ReadString(section, "Info", "");
                Type_String = ini.ReadString(section, "Type", "User");
                Level = ini.ReadInteger(section, "Level", 0);
                Display = ini.ReadBool(section, "Display", true);
            }
            return true;
        }
        public bool Write(TJJS_XML_File ini, string section)
        {
            if (ini != null && section != "")
            {
                ini.WriteString(section, "ID", ID);
                ini.WriteString(section, "Name", Name);
                ini.WriteString(section, "Password", Incode(Password));
                ini.WriteString(section, "Info", Info);
                ini.WriteInteger(section, "Level", Level);
                ini.WriteString(section, "Type", Type_String);
                ini.WriteBool(section, "Display", Display);
            }
            return true;
        }

        static public string Incode(string in_str)
        {
            string result = "";

            if (in_str != "")
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] dataByteArray = Encoding.UTF8.GetBytes(in_str);

                des.Key = key;
                des.IV = iv;
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    result = Convert.ToBase64String(ms.ToArray());
                }
            }
            return result;
        }
        static public string Decode(string in_str)
        {
            string result = "";
            if (in_str != "")
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                des.Key = key;
                des.IV = iv;

                byte[] dataByteArray = Convert.FromBase64String(in_str);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(dataByteArray, 0, dataByteArray.Length);
                        cs.FlushFinalBlock();
                        result = Encoding.UTF8.GetString(ms.ToArray());
                    }
                }
            }
            return result;
        }
    }
    public class TUser_List : CollectionBase
    {
        public string File_Name = "";
       
        public TUser_List()
        {
        }
        public void Copy(TUser_List sor, TUser_List dis)
        {
            dis.List.Clear();
            for (int i = 0; i < sor.Count; i++) dis.List.Add(sor[i]);
        }
        public void Copy(ref TUser_List dis)
        {
            Copy(this, dis);
        }
        public TUser_List Copy()
        {
            TUser_List result = new TUser_List();
            Copy(this, result);
            return result;
        }
        public void Set(TUser_List sor)
        {
            Copy(sor, this);
        }

        public TUser_Info this[int index]
        {
            get
            {
                TUser_Info result = null;
                if (index >= 0 && index < List.Count) result = (TUser_Info)List[index];
                return result;
            }
            set
            {
                if (index >= 0 && index < List.Count)
                {
                    TUser_Info tmp_obj = (TUser_Info)List[index];
                    value.Copy(tmp_obj);
                }
            }
        }
        public TUser_Info this[string id]
        {
            get
            {
                return this[IndexOf_ID(id)];
            }
            set
            {
                this[IndexOf_ID(id)] = value;
            }
        }
        public int IndexOf(TUser_Info member)
        {
            return this.List.IndexOf(member);
        }
        public int IndexOf_ID(string id)
        {
            int result = -1;
            TUser_Info tmp_obj = null;
            for (int i = 0; i < List.Count; i++)
            {
                tmp_obj = (TUser_Info)List[i];
                if (id == tmp_obj.ID)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public int IndexOf_Name(string name)
        {
            int result = -1;
            TUser_Info tmp_obj = null;
            for (int i = 0; i < List.Count; i++)
            {
                tmp_obj = (TUser_Info)List[i];
                if (name == tmp_obj.Name)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        public void Add(TUser_Info member)
        {
            int pos = IndexOf_Name(member.ID);
            if (pos < 0)
            {
                TUser_Info tmp_obj = member.Copy();
                this.List.Add(tmp_obj);
            }
        }
        public void Set_User(TUser_Info member)
        {
            int pos = IndexOf_Name(member.ID);
            if (pos >= 0)
            {
                TUser_Info tmp_obj = this[pos];
                member.Copy(tmp_obj);
            }
        }
        public void Remove(TUser_Info member)
        {
            if (this.IndexOf(member) != -1)
                List.Remove(member);
        }
        public void Remove(string id)
        {
            RemoveAt(IndexOf_Name(id));
        }
        public void Clear()
        {
            List.Clear();
        }

        public void Read()
        {
            Read_File(File_Name);
        }
        public void Read_File(string filename)
        {
            File_Name = filename;
            TJJS_XML_File ini = new TJJS_XML_File(File_Name);
            Clear();
            int count = ini.ReadInteger("Default", "Count", 0);
            for (int i = 0; i < count; i++)
            {
                TUser_Info user = new TUser_Info();
                user.Read(ini, "User" + (i + 1).ToString());
                Add(user);
            }
        }
        public void Write()
        {
            Write_File(File_Name);
        }
        public void Write_File(string filename)
        {
            File_Name = filename;
            TJJS_XML_File ini = new TJJS_XML_File(File_Name);
            ini.WriteInteger("Default", "Count", Count);
            for (int i = 0; i < Count; i++)
            {
                this[i].Write(ini, "User" + (i + 1).ToString());
            }
            ini.Save_File();
        }
    }
}
