namespace Build_School_Project_No_4.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LiveChat")]
    public partial class LiveChat
    {
        public int LiveChatId { get; set; }

        public int LiveSenderId { get; set; }

        public int LiveReceiverId { get; set; }

        public int LiveMessageTypeId { get; set; }

        [Required]
        public string LiveMessageContent { get; set; }

        public DateTime LiveMessageDateTime { get; set; }

        public virtual Members Members { get; set; }

        public virtual Members Members1 { get; set; }

        public virtual MessageType MessageType { get; set; }
    }
}
