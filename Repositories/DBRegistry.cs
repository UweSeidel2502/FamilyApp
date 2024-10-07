using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using FamilyApp.Data;

namespace FamilyApp.Repositories.Registry
{
    public enum Usage
    {
        User,
        Global,
        Client
    }

    /// <summary>
    /// Bereiche der DataBaseregistry (nur für XML-Einstellungen)
    /// </summary>
    /// <remarks></remarks>
    public enum RegistryKeyArea
    {
        /// <summary>
        /// Einstellungen für Druck aus den Janus.GrideEX
        /// </summary>
        /// <remarks></remarks>
        GridExPrint,
        /// <summary>
        /// Einstellungen für Formulare
        /// </summary>
        /// <remarks></remarks>
        Formular,
        /// <summary>
        /// System-Einstellungen für eine Anwendung
        /// </summary>
        /// <remarks></remarks>
        System,
        /// <summary>
        /// Nutzer-Einstellungen für eine Anwendung
        /// </summary>
        /// <remarks></remarks>
        SystemUser,
        /// <summary>
        /// System-Einstellungen für Termine
        /// </summary>
        /// <remarks></remarks>
        Appointment,
        /// <summary>
        /// Nutzer-Einstellungen für Termine
        /// </summary>
        /// <remarks></remarks>
        AppointmentUser
    }

    public partial class DBRegistry : CachedEntityFrameworkRepository<sys_Reg>
    {
        private const string xmlSettingsSection = "Settings";

        public string UserID { get; set; }
        public string ClientID { get; set; }
        private XMLDBReg _xmlReg;
        private string _xmlSection;
        private string _xmlKey;
        private Usage _usageType;

        public DBRegistry(FamilyAppEntities context) : base(context)
        {
        }

        private string UsageKey(Usage usageType)
        {

            switch (usageType)
            {
                case Usage.Global:
                    {
                        return "GLOBAL";
                    }
                case Usage.User:
                    {
                        return UserID.ToLower();
                    }
                case Usage.Client:
                    {
                        return ClientID.ToLower();
                    }

                default:
                    {
                        throw new NotSupportedException();
                    }
            }

        }

        #region Read Setting's and Blob's
        private string GetValue(Usage usageType, string section, string key, object defaultValue)
        {

            try
            {
                var find = this.Find(r => r.REG_ROOT == UsageKey(usageType)  && r.REG_SECTION == section && r.REG_KEY== key).FirstOrDefault();

                if (find == null)
                {
                    return defaultValue.ToString();
                }

                return find.REG_SETTINGS.ToString();
            }
            catch 
            {
                return defaultValue.ToString();
            }

        }

        public string ReadString(Usage usageType, string section, string key, string defaultValue = "")
        {
            return GetValue(usageType, section, key, defaultValue);
        }
        public string ReadString(string root, string section, string key, string defaultValue = "")
        {
            try
            {
                var find = this.Find(r => r.REG_ROOT == root && r.REG_SECTION == section && r.REG_KEY == key).FirstOrDefault();
                if (find == null)
                {
                    return defaultValue.ToString();
                }

                return find.REG_SETTINGS.ToString();
            }
            catch 
            {
                return defaultValue.ToString();
            }

        }


        public int ReadInteger(Usage usageType, string section, string key, int defaultValue = 0)
        {
            string value = GetValue(usageType, section, key, defaultValue);

            int argresult = 0;
            if (int.TryParse(value, out argresult))
            {
                return Convert.ToInt32(value);
            }
            else
            {
                return defaultValue;
            }
        }

        public long ReadInt64(Usage usageType, string section, string key, long defaultValue = 0L)
        {
            string value = GetValue(usageType, section, key, defaultValue);

            long argresult = 0L;
            if (long.TryParse(value, out argresult))
            {
                return Convert.ToInt64(value);
            }
            else
            {
                return defaultValue;
            }
        }

        public double ReadFloat(Usage usageType, string section, string key, double defaultValue = 0d)
        {
            string value = GetValue(usageType, section, key, defaultValue);

            double argresult = 0d;
            if (double.TryParse(value, out argresult))
            {
                return Convert.ToDouble(value);
            }
            else
            {
                return defaultValue;
            }
        }

        public decimal ReadDecimal(Usage usageType, string section, string key, decimal defaultValue = 0m)
        {
            string value = GetValue(usageType, section, key, defaultValue);

            decimal argresult = 0m;
            if (decimal.TryParse(value, out argresult))
            {
                return Convert.ToDecimal(value);
            }
            else
            {
                return defaultValue;
            }
        }

        public bool ReadBoolean(Usage usageType, string section, string key, bool defaultValue = false)
        {
            string value = GetValue(usageType, section, key, defaultValue);

            if (value is string)
            {
                if (value.ToLower() == "true" || value == "-1")
                {
                    value = 1.ToString();
                }
                else
                {
                    value = 0.ToString();
                }
            }

            if (Convert.ToDouble(value) == -1)
                value = 1.ToString();

            int argresult = 0;
            if (int.TryParse(value, out argresult))
            {
                return Convert.ToBoolean(value);
            }
            else
            {
                return defaultValue;
            }
        }

        public MemoryStream ReadBlob(Usage usageType, string section, string key, object defaultValue = null)
        {
            var find = this.Find(r => r.REG_ROOT == UsageKey(usageType) && r.REG_SECTION == section && r.REG_KEY == key).FirstOrDefault();

            if (find == null)
            {
                return (MemoryStream)defaultValue;
            }

            return new MemoryStream(find.REG_BLOB);
        }

        public string ReadBlobAsString(Usage usageType, string section, string key, string defaultValue = null)
        {
            var stream = ReadBlob(usageType, section, key, defaultValue);
            string data = "";

            if (!(stream == null))
            {

                byte[] bArray = stream.ToArray();

                foreach (byte b in bArray)
                {
                    if (b != 0)
                    {
                        data += b.ToString();
                    }
                }

                stream.Close();
                stream = null;
            }

            return data;
        }

        public Guid ReadGuid(Usage usageType, string section, string key, Guid defaultValue = default)
        {
            string value = GetValue(usageType, section, key, defaultValue);

            if (value.Length >= 36)
            {
                return new Guid(value);
            }
            else
            {
                return defaultValue;
            }
        }
        #endregion

        #region SaveSetting, (SaveSettingAsBlob)
        public void SaveSetting(Usage usageType, string section, string key, object settings)
        {
            var find = this.Find(r => r.REG_ROOT == UsageKey(usageType) && r.REG_SECTION == section && r.REG_KEY == key).FirstOrDefault();
            Save(find, settings, section, key, usageType);
        }

        public void SaveSetting(string root, string section, string key, object settings)
        {
            var find = this.Find(r => r.REG_ROOT == root && r.REG_SECTION == section && r.REG_KEY == key).FirstOrDefault();
            Save(find, settings, section, key, Usage.Global, root);
        }

        private void Save(sys_Reg find, object settings, string section, string key, Usage usageType, string root = null)
        {

            if (find == null)
            {
                if (root != null)
                {
                    find = GetNewRegEntity(usageType, section, key, root);
                }
                else
                {
                    find = GetNewRegEntity(usageType, section, key);
                }
                find.REG_SETTINGS = settings.ToString();
                this.Add(find);
            }
            else if (!(settings == null))
            {
                find.REG_SETTINGS = settings.ToString();
            }
            else
            {
                find.REG_SETTINGS = null;
            }

            // TODO kontrollieren
            try
            {
                this.Context.SaveChanges();
            }
            catch 
            {

            }

        }

        public void SaveSettingAsBlob(Usage usageType, string section, string key, MemoryStream settings)
        {
            var find = this.Find(r => r.REG_ROOT == UsageKey(usageType) && r.REG_SECTION == section && r.REG_KEY == key).FirstOrDefault();

            if (find == null)
            {
                find = GetNewRegEntity(usageType, section, key);
                find.REG_BLOB = settings.GetBuffer();
                this.Add(find);
            }
            else if (!(settings == null))
            {
                find.REG_BLOB = settings.GetBuffer();
            }
            else
            {
                find.REG_BLOB = null;
            }


            try
            {
                this.Context.SaveChanges();
            }
            catch 
            {

            }

        }

        public void SaveSettingAsBlobText(Usage usageType, string section, string key, string settings)
        {
            if (settings.Trim().Length > 0)
            {
                var ms = new MemoryStream();

                foreach (char c in settings.ToCharArray())
                    ms.WriteByte((byte)c);

                SaveSettingAsBlob(usageType, section, key, ms);
            }
        }
        private sys_Reg GetNewRegEntity(Usage usageType, string section, string key, string root = null)
        {
            var entity = new sys_Reg();

            entity.REG_KEY = key;
            entity.REG_SECTION = section;
            if (root != null)
            {
                entity.REG_ROOT = root;
            }
            else
            {
                entity.REG_ROOT = UsageKey(usageType);
            }

            return entity;
        }
        #endregion

        #region Delete Setting(s)
        public void DeleteSetting(Usage usageType, string section, string key)
        {
            Delete(this.Find(r => r.REG_ROOT == UsageKey(usageType) && r.REG_SECTION == section && r.REG_KEY == key).ToList());
        }

        public void DeleteSettings(Usage usageType, string section)
        {
            Delete(this.Find(r => r.REG_ROOT == UsageKey(usageType) && r.REG_SECTION == section).ToList());
        }

        public void DeleteSettings(string section)
        {
            Delete(this.Find(r => r.REG_SECTION == section).ToList());
        }

        private void Delete(List<sys_Reg> find)
        {
            if (!(find == null) && find.Count > 0)
            {
                this.Remove(find);
                this.Context.SaveChanges();
            }

        }

        public bool IsValueExists(string root, string section, string key, string value)
        {
            return this.Find(r => r.REG_ROOT == root && r.REG_SECTION == section && r.REG_KEY == key && r.REG_SETTINGS == value).ToList().Count > 0;
        }
        #endregion

        #region XML-DB Registry
        /// <summary>
        /// Startet das Lesen aus der DB-Registry. Nach beenden der einzelnen Werte muss EndReadXML aufgerufen werden.
        /// </summary>
        /// <remarks></remarks>
        public void BeginReadXML(Usage usageType, string section, RegistryKeyArea key)
        {

            try
            {

                _xmlKey = key.ToString();
                _xmlSection = section;
                _usageType = usageType;

                string sXMLString = ReadBlobAsString(usageType, section, key.ToString());
                if (sXMLString == null)
                {
                    sXMLString = "";
                }
                _xmlReg = null;
                _xmlReg = new XMLDBReg();
                _xmlReg.XMLString = sXMLString;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Gibt den Speicher wieder frei.
        /// </summary>
        /// <remarks></remarks>
        public void EndReadXML()
        {

            _xmlKey = null;
            _xmlSection = null;
            _xmlReg = null;

        }
        /// <summary>
        /// Liest den Werte als String aus der XML-Deklaration vom angegebenen Schlüssel.
        /// </summary>
        public string ReadXMLString(string key, string defaultValue)
        {

            if (!(_xmlReg == null))
            {
                return _xmlReg.ReadValue(xmlSettingsSection, key, defaultValue);
            }
            else
            {
                return defaultValue;
            }

        }
        /// <summary>
        /// Liest den Werte als String aus der XML-Deklaration vom angegebenen Schlüssel (Aufruf von BeginReadXML und EndReadXML wird hier durchgeführt).
        /// </summary>
        public string ReadXMLString(Usage usageType, string section, RegistryKeyArea key, string xmlkey, string defaultValue = "")
        {

            try
            {
                BeginReadXML(usageType, section, key);
                return ReadXMLString(xmlkey, defaultValue);
            }
            finally
            {
                EndReadXML();
            }

        }
        /// <summary>
        /// Liest den Werte als Boolean aus der XML-Deklaration vom angegebenen Schlüssel.
        /// </summary>
        public bool ReadXMLBoolean(string key, bool defaultValue)
        {
            if (!(_xmlReg == null))
            {
                return _xmlReg.ReadValueAsBoolean(xmlSettingsSection, key, defaultValue);
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// Liest den Werte als Boolean aus der XML-Deklaration vom angegebenen Schlüssel (Aufruf von BeginReadXML und EndReadXML wird hier durchgeführt).
        /// </summary>
        public bool ReadXMLBoolean(Usage usageType, string section, RegistryKeyArea key, string xmlkey, bool defaultValue = false)
        {
            try
            {
                BeginReadXML(usageType, section, key);
                return ReadXMLBoolean(xmlkey, defaultValue);
            }
            finally
            {
                EndReadXML();
            }
        }
        /// <summary>
        /// Liest den Werte als Int16 aus der XML-Deklaration vom angegebenen Schlüssel.
        /// </summary>
        public short ReadXMLInt16(string key, short defaultValue)
        {

            if (!(_xmlReg == null))
            {
                return _xmlReg.ReadValueAsInt16(xmlSettingsSection, key, defaultValue);
            }
            else
            {
                return defaultValue;
            }

        }
        /// <summary>
        /// Liest den Werte als Int16 aus der XML-Deklaration vom angegebenen Schlüssel (Aufruf von BeginReadXML und EndReadXML wird hier durchgeführt).
        /// </summary>
        public short ReadXMLInt16(Usage usageType, string section, RegistryKeyArea key, string xmlkey, short defaultValue = 0)
        {

            try
            {
                BeginReadXML(usageType, section, key);
                return ReadXMLInt16(xmlkey, defaultValue);
            }
            finally
            {
                EndReadXML();
            }

        }
        /// <summary>
        /// Liest den Werte als Int32 aus der XML-Deklaration vom angegebenen Schlüssel.
        /// </summary>
        public int ReadXMLInt32(string key, int defaultValue)
        {

            if (!(_xmlReg == null))
            {
                return _xmlReg.ReadValueAsInt32(xmlSettingsSection, key, defaultValue);
            }
            else
            {
                return defaultValue;
            }

        }
        /// <summary>
        /// Liest den Werte als Int32 aus der XML-Deklaration vom angegebenen Schlüssel (Aufruf von BeginReadXML und EndReadXML wird hier durchgeführt).
        /// </summary>
        public int ReadXMLInt32(Usage usageType, string section, RegistryKeyArea key, string xmlkey, int defaultValue = 0)
        {
            try
            {
                BeginReadXML(usageType, section, key);
                return ReadXMLInt32(xmlkey, defaultValue);
            }
            finally
            {
                EndReadXML();
            }
        }
        /// <summary>
        /// Liest den Werte als Int64 aus der XML-Deklaration vom angegebenen Schlüssel.
        /// </summary>
        public long ReadXMLInt64(string key, long defaultValue)
        {
            if (!(_xmlReg == null))
            {
                return _xmlReg.ReadValueAsInt64(xmlSettingsSection, key, defaultValue);
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// Liest den Werte als Int64 aus der XML-Deklaration vom angegebenen Schlüssel (Aufruf von BeginReadXML und EndReadXML wird hier durchgeführt).
        /// </summary>
        public long ReadXMLInt64(Usage usageType, string section, RegistryKeyArea key, string xmlkey, long defaultValue = 0L)
        {
            try
            {
                BeginReadXML(usageType, section, key);
                return ReadXMLInt64(xmlkey, defaultValue);
            }
            finally
            {
                EndReadXML();
            }
        }
        /// <summary>
        /// Liest den Werte als Double aus der XML-Deklaration vom angegebenen Schlüssel.
        /// </summary>
        public double ReadXMLDouble(string key, double defaultValue)
        {
            if (!(_xmlReg == null))
            {
                return _xmlReg.ReadValueAsDouble(xmlSettingsSection, key, defaultValue);
            }
            else
            {
                return defaultValue;
            }
        }
        /// <summary>
        /// Liest den Werte als Double aus der XML-Deklaration vom angegebenen Schlüssel (Aufruf von BeginReadXML und EndReadXML wird hier durchgeführt).
        /// </summary>
        public double ReadXMLDouble(Usage usageType, string section, RegistryKeyArea key, string xmlkey, double defaultValue = 0d)
        {
            try
            {
                BeginReadXML(usageType, section, key);
                return ReadXMLDouble(xmlkey, defaultValue);
            }
            finally
            {
                EndReadXML();
            }
        }
        /// <summary>
        /// Liest den Werte als Date aus der XML-Deklaration vom angegebenen Schlüssel.
        /// </summary>
        /// <remarks></remarks>
        public DateTime ReadXMLDate(string key, DateTime defaultValue)
        {

            if (!(_xmlReg == null))
            {
                return _xmlReg.ReadValueAsDate(xmlSettingsSection, key, defaultValue);
            }
            else
            {
                return defaultValue;
            }

        }
        /// <summary>
        /// Liest den Werte als Date aus der XML-Deklaration vom angegebenen Schlüssel (Aufruf von BeginReadXML und EndReadXML wird hier durchgeführt).
        /// </summary>
        public DateTime ReadXMLDate(Usage usageType, string section, RegistryKeyArea key, string xmlkey, DateTime defaultValue = default)
        {
            try
            {
                BeginReadXML(usageType, section, key);
                return ReadXMLDate(xmlkey, defaultValue);
            }
            finally
            {
                EndReadXML();
            }
        }
        /// <summary>
        /// Liest den Werte als GUID aus der XML-Deklaration vom angegebenen Schlüssel.
        /// </summary>
        public object ReadXMLGuid(string key, object defaultValue)
        {

            if (!(_xmlReg == null))
            {
                string sGuid = _xmlReg.ReadValue(xmlSettingsSection, key, "");
                if (string.IsNullOrEmpty(sGuid))
                {
                    if (!(defaultValue == null))
                    {
                        return defaultValue;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    try
                    {
                        return new Guid(sGuid);
                    }
                    catch 
                    {
                        return null;
                    }
                }
            }
            else
            {
                return defaultValue;
            }

        }
        /// <summary>
        /// Liest den Werte als GUID aus der XML-Deklaration vom angegebenen Schlüssel (Aufruf von BeginReadXML und EndReadXML wird hier durchgeführt).
        /// </summary>
        public object ReadXMLGuid(Usage usageType, string section, RegistryKeyArea key, string xmlkey, object defaultValue = null)
        {
            try
            {
                BeginReadXML(usageType, section, key);
                return ReadXMLGuid(xmlkey, defaultValue);
            }
            finally
            {
                EndReadXML();
            }
        }

        /// <summary>
        /// Startet den Schreibvorgang für der XML-Deklaration. Nachdem alle Werte geschrieben wurden, muss "EndWriteXML" aufgerufen werden. Erst dann werden die Daten gespeichert.
        /// </summary>
        public void BeginWriteXML(Usage usageType, string section, RegistryKeyArea key)
        {

            try
            {

                _xmlKey = key.ToString();
                _xmlSection = section;
                _usageType = usageType;

                string sXMLString = ReadBlobAsString(usageType, section, key.ToString());
                if (sXMLString == null)
                {
                    sXMLString = "";
                }

                _xmlReg = null;
                _xmlReg = new XMLDBReg();
                _xmlReg.XMLString = sXMLString;
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Speichert die XML-Deklaration in die Datenbank und gibt den Speicher wieder frei.
        /// </summary>
        /// <remarks></remarks>
        public void EndWriteXML()
        {

            if (!(_xmlReg == null))
            {
                SaveSettingAsBlobText(_usageType, _xmlSection, _xmlKey, _xmlReg.XMLString);
            }

            _xmlKey = null;
            _xmlSection = null;
            _xmlReg = null;

        }
        /// <summary>
        /// Speichert einzelne Werte in die XML-Deklaration vom angegebenen Schlüssel. Wenn ASettings = Nothing, dann wird keine Wert gespeichert!
        /// </summary>
        /// <remarks></remarks>
        public void SaveXMLSettings(string key, object settings)
        {

            if (!(_xmlReg == null) & !(settings == null))
            {
                _xmlReg.WriteValue(xmlSettingsSection, key, settings.ToString());
            }

        }
        /// <summary>
        /// Speichert einzelne Werte in die XML-Deklaration vom angegebenen Schlüssel (Aufruf von BeginWriteXML und EndWriteXML wird hier durchgeführt).
        /// Wenn ASettings = Nothing, dann wird keine Wert gespeichert!
        /// </summary>
        /// <remarks></remarks>
        public void SaveXMLSettings(Usage usageType, string section, RegistryKeyArea key, string xmlkey, object settings)
        {

            try
            {
                BeginWriteXML(usageType, section, key);
                SaveXMLSettings(xmlkey, settings);
            }
            finally
            {
                EndWriteXML();
            }

        }
        #endregion

        /// <summary>
        /// Hilfsklasse
        /// </summary>
        private partial class XMLDBReg
        {
            private string _rootNodeName = "XMLDBReg";
            private string _xmlString = "";
            private XmlDocument _xmlDoc;
            public string XMLString
            {
                get
                {
                    return _xmlString;
                }
                set
                {
                    _xmlString = value;
                }
            }

            /// <summary>
            /// Stammelementname (sollte der Anwendungsname sein).
            /// </summary>
            public string RootNodeName
            {
                get
                {
                    return _rootNodeName;
                }
                set
                {
                    _rootNodeName = value;
                }
            }
            private void LoadXMLString()
            {

                if (_xmlDoc == null)
                {
                    _xmlDoc = new XmlDocument();

                    if (!string.IsNullOrEmpty(_rootNodeName))
                    {

                        if (string.IsNullOrEmpty(_xmlString))
                        {
                            var XmlDeclaration = _xmlDoc.CreateXmlDeclaration("1.0", "ISO-8859-1", null);
                            _xmlDoc.InsertBefore(XmlDeclaration, _xmlDoc.DocumentElement);
                            var RootNode = _xmlDoc.CreateElement(_rootNodeName);
                            _xmlDoc.AppendChild(RootNode);
                            _xmlString = _xmlDoc.InnerXml;
                        }

                        _xmlDoc.LoadXml(_xmlString);
                    }

                    else
                    {
                        throw new Exception("RootNodeName is not assign!");
                    }

                }

            }
            public bool WriteValue(string section, string key, string AValue)
            {

                XmlNode ValueNode;

                try
                {

                    LoadXMLString();

                    if (section.EndsWith(@"\"))
                    {
                        section += key;
                    }
                    else
                    {
                        section += @"\" + key;
                    }

                    ValueNode = GetNode(section);

                    if (ValueNode == null)
                    {
                        InsertTextNode(ValueNode, key, AValue);
                    }
                    else
                    {
                        ValueNode.InnerText = AValue;
                    }

                    _xmlString = _xmlDoc.InnerXml;

                    return true;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            public string ReadValue(string section, string key, string defaultValue = "")
            {
                string ReadValueRet = default;

                XmlNode ValueNode;

                ReadValueRet = defaultValue;

                try
                {

                    if (section.EndsWith(@"\"))
                    {
                        section += key;
                    }
                    else
                    {
                        section += @"\" + key;
                    }

                    LoadXMLString();
                    ValueNode = GetNode(section);

                    if (ValueNode == null)
                    {
                        return defaultValue;
                    }

                    if (ValueNode == null)
                    {
                        return defaultValue;
                    }
                    else if (!(ValueNode.FirstChild == null))
                    {
                        return ValueNode.FirstChild.Value;
                    }
                    else if (ValueNode.Value == null)
                    {
                        return defaultValue;
                    }
                    else
                    {
                        return ValueNode.InnerText;

                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            private XmlNode GetNextNode(string ANodeName, XmlNode ANode)
            {

                if (ANode.HasChildNodes)
                {
                    foreach (XmlNode NodeLoop in ANode.ChildNodes)
                    {
                        if ((NodeLoop.Name ?? "") == (ANodeName ?? ""))
                        {
                            return NodeLoop;
                        }
                        else
                        {
                            GetNextNode(ANodeName, NodeLoop);
                        }
                    }
                }

                return null;

            }
            private XmlNode GetNode(string APath, XmlNode ANode = null)
            {
                XmlNode SectionNode = null;
                XmlNode Node;

                try
                {
                    string[] separators = { @"/" };
                    string[] Sections = APath.Split(separators, StringSplitOptions.None);

                    if (!(ANode == null))
                    {
                        SectionNode = ANode;
                    }
                    else
                    {
                        SectionNode = _xmlDoc.LastChild;
                    }

                    Node = SectionNode;
                    foreach (string s in Sections)
                    {

                        if ((SectionNode.Name ?? "") == (Sections[Sections.Length - 1] ?? "") | string.IsNullOrEmpty(s))
                        {
                            break;
                        }
                        else
                        {
                            SectionNode = GetNextNode(s, SectionNode);
                            if (SectionNode == null)
                            {
                                SectionNode = Node.AppendChild(_xmlDoc.CreateElement(s));
                            }
                            Node = SectionNode;
                        }

                    }

                    return SectionNode;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            public ArrayList ReadAllValues(string section)
            {
                ArrayList ReadAllValuesRet = default;

                XmlNode SectionNode;
                var sData = new ArrayList();

                ReadAllValuesRet = sData;
                try
                {
                    LoadXMLString();
                    SectionNode = GetNode(section);

                    if (SectionNode.HasChildNodes)
                    {
                        foreach (XmlNode xNodeLoop in SectionNode.ChildNodes)
                        {
                            if (!(xNodeLoop.FirstChild == null))
                            {
                                sData.Insert(sData.Count, xNodeLoop.FirstChild.Value);
                            }
                            else
                            {
                                sData.Insert(sData.Count, xNodeLoop.InnerText);
                            }
                        }
                    }

                    return sData;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            public ArrayList ReadAllNames(string section)
            {
                ArrayList ReadAllNamesRet = default;

                XmlNode SectionNode;
                var sData = new ArrayList();

                ReadAllNamesRet = sData;
                try
                {
                    LoadXMLString();
                    SectionNode = GetNode(section);

                    if (SectionNode.HasChildNodes)
                    {
                        foreach (XmlNode xNodeLoop in SectionNode.ChildNodes)
                            sData.Insert(sData.Count, xNodeLoop.Name);
                    }

                    return sData;
                }

                catch (Exception ex)
                {
                    throw ex;
                }

            }
            public double ReadValueAsDouble(string section, string key, double defaultValue = 0d)
            {
                string s = ReadValue(section, key);

                double argresult = 0d;
                if (double.TryParse(s, out argresult))
                {
                    return Convert.ToDouble(s);
                }

                return defaultValue;
            }
            public short ReadValueAsInt16(string section, string key, short defaultValue = 0)
            {
                string s = ReadValue(section, key);

                short argresult = 0;
                if (short.TryParse(s, out argresult))
                {
                    return Convert.ToInt16(s);
                }

                return defaultValue;
            }
            public int ReadValueAsInt32(string section, string key, int defaultValue = 0)
            {
                string s = ReadValue(section, key);

                int argresult = 0;
                if (int.TryParse(s, out argresult))
                {
                    return Convert.ToInt32(s);
                }

                return defaultValue;
            }
            public long ReadValueAsInt64(string section, string key, long defaultValue = 0L)
            {
                string s = ReadValue(section, key);

                long argresult = 0L;
                if (long.TryParse(s, out argresult))
                {
                    return Convert.ToInt64(s);
                }

                return defaultValue;
            }
            public bool ReadValueAsBoolean(string section, string key, bool defaultValue = false)
            {
                string value = ReadValue(section, key);

                if (string.IsNullOrEmpty(value))
                {
                    value = Convert.ToString(defaultValue);
                }

                if (value is string)
                {
                    if (value.ToLower() == "true")
                    {
                        value = 1.ToString();
                    }
                    else
                    {
                        value = 0.ToString();
                    }
                }

                int argresult = 0;
                if (int.TryParse(value, out argresult))
                {
                    return Convert.ToBoolean(value);
                }
                else
                {
                    return defaultValue;
                }

            }
            public DateTime ReadValueAsDate(string section, string key, DateTime defaultValue = default)
            {
                string s = ReadValue(section, key);

                var argresult = DateTime.Today;
                if (DateTime.TryParse(s, out argresult))
                {
                    return Convert.ToDateTime(s);
                }
                    return defaultValue;
            }

            private XmlElement InsertTextNode(XmlNode ANode, string ATag, string AValue)
            {

                XmlNode NodeTemp;

                NodeTemp = _xmlDoc.CreateElement(ATag);
                NodeTemp.AppendChild(_xmlDoc.CreateTextNode(AValue));
                ANode.AppendChild(NodeTemp);

                return (XmlElement)NodeTemp;

            }
            public bool DeleteKey(string section, string key)
            {
                XmlNode SectionNode;

                try
                {

                    LoadXMLString();
                    SectionNode = GetNode(section);
                    try
                    {
                        SectionNode.RemoveChild(SectionNode.SelectSingleNode(key));
                        _xmlString = _xmlDoc.InnerXml;
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public bool DeleteSection(string section)
            {
                XmlNode RootNode;

                try
                {

                    LoadXMLString();

                    try
                    {
                        RootNode = GetNode(section).ParentNode;
                        RootNode.RemoveChild(GetNode(section));
                        _xmlString = _xmlDoc.InnerXml;
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }

    }

}