using System;

namespace MilenialPark.Models
{
    /// <summary>
    /// Represents a single RFID tag record. This class is used as a plain
    /// data container when inserting or updating RFID information. Each tag
    /// is identified by its TagID and TypeRFID (the physical form, e.g.
    /// gelang, gantungan, kartu). Additional fields such as RFIDName,
    /// Status and LastScan are also stored.
    /// </summary>
    public class ClsRFID
    {
        /// <summary>
        /// The unique identifier of the RFID tag (UID/EPC). This value
        /// comes directly from the tag and is typically a hexadecimal
        /// string.
        /// </summary>
        public string TagID { get; set; }

        /// <summary>
        /// A human‑readable name or number printed on the tag. For
        /// example "001" or "Gel_Biru". Used by the cashier/operator.
        /// </summary>
        public string RFIDName { get; set; }

        /// <summary>
        /// The physical type of the RFID tag, such as "gelang" (wristband),
        /// "gantungan" (keychain), or "kartu" (card).
        /// </summary>
        public string TypeRFID { get; set; }

        /// <summary>
        /// Indicates whether the tag is active. When false, the tag is
        /// considered deactivated and should not be assigned to new
        /// transactions. Stored as a BIT in SQL Server.
        /// </summary>
        public bool Status { get; set; }

        /// <summary>
        /// Optional timestamp of the last time the tag was scanned.
        /// This field can be null if no scans have been recorded.
        /// </summary>
        public DateTime? LastScan { get; set; }

        /// <summary>
        /// Default constructor. Initializes an empty RFID record.
        /// </summary>
        public ClsRFID()
        {
        }

        /// <summary>
        /// Constructs a new RFID record with the required fields. The
        /// optional last scan timestamp is left null.
        /// </summary>
        /// <param name="tagID">The unique tag identifier.</param>
        /// <param name="rfidName">The human‑readable tag name.</param>
        /// <param name="typeRFID">The physical type of the tag.</param>
        /// <param name="status">True if the tag is active.</param>
        public ClsRFID(string tagID, string rfidName, string typeRFID, bool status)
        {
            TagID = tagID;
            RFIDName = rfidName;
            TypeRFID = typeRFID;
            Status = status;
            LastScan = null;
        }
    }
}