﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The many-to-many entity class of authors and exhibitions.
    /// </summary>
    public class AuthorExhibition
    {
        /// <summary>
        /// Unique identifier of the author.
        /// </summary>
        [Comment("Author's unique identifier. | Уникален идентификатор на автора.")]
        public int AuthorId { get; set; }

        /// <summary>
        /// Navigation property of the author.
        /// </summary>
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; } = null!;

        /// <summary>
        /// Unique identifier of the exhibition.
        /// </summary>
        [Comment("Exhibition's unique identifier. | Уникален идентификатор на изложбата.")]
        public int ExhibitionId { get; set; }

        /// <summary>
        /// Navigation property of the exhibition.
        /// </summary>
        public Exhibition Exhibition { get; set; } = null!;
    }
}
