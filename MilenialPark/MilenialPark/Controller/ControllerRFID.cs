using System;
using System.Data;
using MilenialPark.Models;
using MilenialPark.Master;

namespace MilenialPark.Controller
{
    /// <summary>
    /// Provides CRUD operations for the RFIDTags table. This controller
    /// encapsulates all SQL queries needed to insert, update, delete
    /// and retrieve RFID tag records. It utilises the global database
    /// connection exposed via ClsStaticVariable.objConnection.
    /// </summary>
    public class ControllerRFID
    {
        /// <summary>
        /// Returns a DataTable containing all RFID tags. Columns include
        /// TagID, RFIDName, TypeRFID, Status and LastScan. The records
        /// are ordered by TagID and TypeRFID for easier viewing.
        /// </summary>
        /// <returns>A DataTable of RFID tags.</returns>
        public DataTable GetRFIDList()
        {
            string query = "SELECT TagID, RFIDName, TypeRFID, Status, LastScan FROM RFIDTags ORDER BY TagID, TypeRFID";
            return ClsStaticVariable.objConnection.objsqlconnection.Filldatatable(query);
        }

        /// <summary>
        /// Checks whether an RFID tag already exists based on the natural
        /// key TagID + TypeRFID. Returns true if at least one record
        /// matches both values.
        /// </summary>
        /// <param name="tagID">The UID of the tag.</param>
        /// <param name="typeRFID">The physical type of the tag.</param>
        /// <returns>True if the record exists; otherwise false.</returns>
        public bool CheckRFID(string tagID, string typeRFID)
        {
            string query = $"SELECT COUNT(*) FROM RFIDTags WHERE TagID = {ClsFungsi.C2Q(tagID)} AND TypeRFID = {ClsFungsi.C2Q(typeRFID)}";
            object result = ClsStaticVariable.objConnection.objsqlconnection.ExecuteScalar(query);
            if (result == null || result == DBNull.Value) return false;
            int count;
            return int.TryParse(result.ToString(), out count) && count > 0;
        }

        /// <summary>
        /// Inserts a new RFID record into the RFIDTags table. The LastScan
        /// column is left null on creation. Throws an exception if the
        /// underlying ExecuteNonQuery fails.
        /// </summary>
        /// <param name="rfid">The RFID record to insert.</param>
        public void InsertRFID(ClsRFID rfid)
        {
            string query = $"INSERT INTO RFIDTags (TagID, RFIDName, TypeRFID, Status, LastScan) VALUES (" +
                           $"{ClsFungsi.C2Q(rfid.TagID)}, {ClsFungsi.C2Q(rfid.RFIDName)}, {ClsFungsi.C2Q(rfid.TypeRFID)}, " +
                           $"{(rfid.Status ? 1 : 0)}, NULL)";
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Updates an existing RFID record identified by TagID and TypeRFID.
        /// Only the RFIDName, Status and optionally LastScan fields are
        /// modified. The primary key values are not changed.
        /// </summary>
        /// <param name="rfid">The RFID record containing updated data.</param>
        public void UpdateRFID(ClsRFID rfid)
        {
            string query = $"UPDATE RFIDTags SET " +
                           $"RFIDName = {ClsFungsi.C2Q(rfid.RFIDName)}, " +
                           $"Status = {(rfid.Status ? 1 : 0)} " +
                           $"WHERE TagID = {ClsFungsi.C2Q(rfid.TagID)} AND TypeRFID = {ClsFungsi.C2Q(rfid.TypeRFID)}";
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }

        /// <summary>
        /// Deletes an RFID record identified by its TagID and TypeRFID.
        /// </summary>
        /// <param name="tagID">The UID of the tag.</param>
        /// <param name="typeRFID">The physical type of the tag.</param>
        public void DeleteRFID(string tagID, string typeRFID)
        {
            string query = $"DELETE FROM RFIDTags WHERE TagID = {ClsFungsi.C2Q(tagID)} AND TypeRFID = {ClsFungsi.C2Q(typeRFID)}";
            ClsStaticVariable.objConnection.objSqlServerIUDClass.ExecuteNonQuery(query);
        }
    }
}