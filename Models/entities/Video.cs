using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProStudy_NET.Models.Entities
{
     [Table("videos")]
    public class Video
    {
        [Key]
        [Column("videoid")]
        [StringLength(11)]
        public required string VideoId { get; set; }

        [Required]
        [StringLength(255)]
        [Column("videotitle")]
        public required string VideoTitle { get; set; } = string.Empty;

        [Column("videothumb")]
        public required string VideoThumbnail { get; set; } = string.Empty;

        [ForeignKey("CategoryId")]
        [JsonIgnore]
        public required Category Category { get; set; }

        [Column("categoryid")]
        public required long CategoryId { get; set; }

        public Video() { }

        public Video(string videoId, string videoTitle, string videoThumbnail, long categoryId)
        {
            VideoId = videoId;
            VideoTitle = videoTitle;
            VideoThumbnail = videoThumbnail;
            CategoryId = categoryId;
        }
    }
}