namespace Program.Models
{
    public record Playlist
    {
        public Guid Id { get; init; }
        public string Musicname { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Imglink { get; set; }
        public string Musiclink { get; set; }

        public Playlist(Guid id, string musicname, string genre, string album, string artist, string imglink, string musiclink)
        {
            Id = id;
            Musicname = musicname;
            Genre = genre;
            Album = album;
            Artist = artist;
            Imglink = imglink;
            Musiclink = musiclink;
        }
    }

    public class MusicNamePatchModel
    {
        public string Musicname { get; set; } = string.Empty;
    }
}
