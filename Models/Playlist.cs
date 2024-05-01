namespace Program.Models
{
    public record Playlist
    {
        
        public Guid Id { get; init; }

        public string Musicname { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }

        public Playlist(Guid id, string musicname, string genre, string album, string artist)
        {
            Id = id;
            Musicname = musicname;
            Genre = genre;
            Album = album;
            Artist = artist;
        }
    }
    public class MusicNamePatchModel
{
    public string Musicname { get; set; } = "";
}
}   