import React, { useState } from "react";

const FormularioPlaylist: React.FC = () => {
    const [Musicname, setMusicname] = useState("");
    const [genre, setGenre] = useState("");
    const [album, setAlbum] = useState("");
    const [artist, setArtist] = useState("");
    const [imglink, setImglink] = useState("");
    const [musiclink, setMusiclink] = useState("");

    const submeter = async (event: React.FormEvent<HTMLFormElement>) => {
        event.preventDefault();
    
        const queryString = new URLSearchParams({
            Musicname: Musicname,
            genre: genre,
            album: album,
            artist: artist,
            imglink: imglink,
            musiclink: musiclink,
        }).toString();
    
        try {
            const resposta = await fetch(`http://localhost:4000/api/Playlist/adicionar?${queryString}`, {
                method: "POST",
            });
    
            if (resposta.ok) {
                alert("Musica Adicionada!");
            } else {
                alert("Erro ao adicionar musica.");
            }
        } catch (error) {
            console.error("Ocorreu um erro:", error);
        }
    };

    return (
        <div>
            <form onSubmit={submeter}>
                <input type="text" name="musicname" onChange={(e) => setMusicname(e.target.value)} placeholder="Music Name" required />
                <input type="text" name="album" placeholder="Album" value={album} onChange={(e) => setAlbum(e.target.value)} required />
                <input type="text" name="artist" placeholder="Artist" onChange={(e) => setArtist(e.target.value)} required />
                <input type="text" name="genre" placeholder="Genre" onChange={(e) => setGenre(e.target.value)} required />
                <input type="text" name="imglink" placeholder="Image Link" onChange={(e) => setImglink(e.target.value)} required />
                <input type="text" name="musiclink" placeholder="Music Link" onChange={(e) => setMusiclink(e.target.value)} required />
                <button type="submit">Add Music</button>
            </form>
        </div>
        
        
        
    );
};

export default FormularioPlaylist;
