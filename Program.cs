using Microsoft.AspNetCore.JsonPatch;
using Program.Models;
using Programdata.Data;


class Programs
{

    static void Main(string[] args)
    {
        //web aplication configuração
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers().AddNewtonsoftJson();
        builder.Services.AddOpenApiDocument(config =>
        {
            config.DocumentName = "Playlist_Program";
            config.Title = "Playlist v1";
            config.Version = "v1";
        });

        var origins = "_origins";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: origins, policy =>
            {
                policy.WithOrigins("http://localhost:3000") 
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        builder.Services.AddDbContext<AppDbContext>();
        WebApplication app = builder.Build();
        app.UseCors(origins);
        app.UseRouting();
        app.MapControllers();

        // Recupera todos os valores dentro da playlist
        app.MapGet("/api/Playlist", (AppDbContext context) =>
        {
            var playlists = context.Playlist;
            return playlists is not null ? Results.Ok(playlists) : Results.NotFound();
        }).Produces<Playlist>();


        //Apenas nomes das musicas
        app.MapGet("/api/Playlist/musics", (AppDbContext context) =>
        {
            var musics = context.Playlist
            .Select(x => x.Musicname)
            .Distinct()
            .ToList();

            if (musics.Count > 0)
            {
                return Results.Ok(musics);

            }
            else
            {
                return Results.NotFound();
            }
        }).Produces<List<string>>();




        //Apenas os artistas
        app.MapGet("/api/Playlist/artists", (AppDbContext context) =>
        {
            var artists = context.Playlist
            .Select(p => p.Artist)
            .Distinct()
            .ToList();
            if (artists.Count > 0)
            {
                return Results.Ok(artists);
            }
            else
            {
                return Results.NotFound();
            }
        }).Produces<List<string>>();




        //Adicionar musica na playlist
        app.MapPost("/api/Playlist/adicionar", (AppDbContext context, string Musicname, string genre, string album, string artist, string imglink, string musiclink) =>
        {
            var music = new Playlist(Guid.NewGuid(), Musicname, genre, album, artist, imglink, musiclink);

            context.Playlist.Add(music);
            context.SaveChanges();

            return Results.Ok(music);
        }).Produces<Playlist>();





        //Deletar musica na playlist
        app.MapDelete("/api/Playlist/{id}", (AppDbContext context, Guid id) =>
        {
            var playlist = context.Playlist.Find(id);
            if (playlist == null)
            {
                return Results.NotFound();
            }
            context.Playlist.Remove(playlist);
            context.SaveChanges();
            return Results.Ok(playlist);
        }).Produces<Playlist>();




        // Atualizar musica na playlist
        app.MapPut("/api/Playlist/", (Playlist updatedPlaylist, AppDbContext context) =>
        {
            var playlist = context.Playlist.Find(updatedPlaylist.Id);
            if (playlist == null)
            {
                return Results.NotFound();
            }

            var entry = context.Entry(playlist).CurrentValues;

            entry.SetValues(updatedPlaylist);

            context.SaveChanges();

            return Results.Ok(playlist);
        }).Produces<Playlist>();



        //Atualizar playlist parcialmente (nome da musica)
        app.MapPatch("/api/Playlist/patch{id}", (Guid id, MusicNamePatchModel musicpatch, AppDbContext context) =>
        {
            var playlist = context.Playlist.Find(id);
            if (playlist == null)
            {
                return Results.NotFound();
            }

            if (!string.IsNullOrEmpty(musicpatch.Musicname)) // se não estiver vazio
            {
                playlist.Musicname = musicpatch.Musicname; // !
            }
            else
            {
                Console.WriteLine("Erro! o nome da musica não foi digitado");
            }

            context.SaveChanges();

            return Results.Ok(playlist);

        }).Produces<Playlist>();
        app.Run();
    }
}
