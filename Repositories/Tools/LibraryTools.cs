using System;
using FamilyApp;
using FamilyApp.Data;
namespace FamilyApp.Repositories
{ 
    #region Enums und Structures
    public enum LogAction
    {
    laInsert = 1,
    laUpdate = 2,
    laUpdateBatch = 3,
    laDelete = 4,
    laDeleteBatch = 5,
    laInsertTable = 6,
    laInsertField = 7,
    laDeleteField = 8,
    laDeleteTable = 9
    }

    public abstract partial class StandardFilterArgs
    {
    public string FilterName;
    public string ID;
    public string NodeKey;
    public int FLAG;

    private string _filterSQL;
    public string FilterSQL
    {
        get
        {
            return _filterSQL;
        }
        set
        {
            _filterSQL = value;
        }
    }
    public string SQL;
    public string InStatement;
    }
    public partial class FilterArgs : StandardFilterArgs
    {

    }

    #endregion

    public partial class EventLog
    {
    private  FamilyAppEntities _context;
    private bool _isEventLog;
    //private string _applicationName;
    private string _userName;
    public object UserName
    {
        get
        {
            return _userName;
        }
    }
    public EventLog(FamilyAppEntities context, bool isEventLog, string userName) : base()
    {
        _context = context;
        _isEventLog = isEventLog;
        _userName = userName;
    }

    }

    public partial class Tools
    {
    public static object CloneChildEntity(FamilyAppEntities dataFactory, object currentEntity, object newEntity, Guid newGuid)
    {

        var sourceValues = dataFactory.Entry(currentEntity).CurrentValues;
        dataFactory.Entry(newEntity).CurrentValues.SetValues(sourceValues);
        ((dynamic)newEntity).GUID = Guid.NewGuid();
        ((dynamic)newEntity).INVNR_GUID = newGuid;

        return newEntity;
    }

    public static object CloneEntity(FamilyAppEntities dataFactory, object currentEntity, object newEntity)
    {

        var sourceValues = dataFactory.Entry(currentEntity).CurrentValues;
        dataFactory.Entry(newEntity).CurrentValues.SetValues(sourceValues);
        ((dynamic)newEntity).GUID = Guid.NewGuid();

        return newEntity;
    }


    }

    public partial class PersonalName
    {

    public Guid GUID { get; set; }
    private string FirstName;
    private string LastName;
    private string AdditionalText;
    public PersonalName(Guid guid, string firstName, string lastName, string additionalText = null)
    {
        GUID = guid;
        FirstName = firstName;
        LastName = lastName;
        AdditionalText = additionalText;
    }
    public string FullName
    {
        get
        {

            string result;
            if (!string.IsNullOrEmpty(FirstName))
            {
                result = LastName + " " + FirstName;
            }
            else
            {
                result = LastName;
            }

            if (!string.IsNullOrEmpty(AdditionalText))
            {
                result += " - " + AdditionalText;
            }

            return result;
        }
    }
    }

    public partial class LinkText
    {
    public Guid GUID { get; set; }
    private string DescriptionValue;
    private string RemarkValue;
    public LinkText(Guid guid, string descriptionValue, string remarkValue)
    {
        GUID = guid;
        DescriptionValue = descriptionValue.Trim();
        if (!string.IsNullOrEmpty(remarkValue))
        {
            RemarkValue = remarkValue.Trim();
        }
        else
        {
            RemarkValue = "";
        }
    }
    public string Description
    {
        get
        {
            if (!string.IsNullOrEmpty(RemarkValue))
            {
                return DescriptionValue + " - " + RemarkValue;
            }
            else
            {
                return DescriptionValue;
            }
        }
    }
    }

    public partial class NameInfo
    {
    public object ObjectID { get; set; }
    private string _name;
    public NameInfo(object objectID, string name)
    {
        ObjectID = objectID;
        _name = name;
    }
    public string Name
    {
        get
        {
            return _name;
        }
    }
    }
}