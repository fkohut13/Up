import React, { useState, useEffect } from 'react';
import playicon from "./play.svg"
import deleteicon from "./delete.svg"
import editicon from "./edit.svg"
import './App.css';
import FormularioPlaylist from './formulario'

interface Music {
  id: string;
  musicname: string;
  album: string;
  artist: string;
  genre: string;
  imglink: string;
  musiclink: string;
}


function App() {
  const [playlist, setarPlaylist] = useState<Music[]>([]);
  const [newMusicName, setNewMusicName] = useState('');
  const [mostrarInput, setmostrarInput] = useState(false);
  const abrirInput= () => {
    if (mostrarInput == false) {
      setmostrarInput(true);
    } else {
      setmostrarInput(false);
    }
    
  };

  useEffect(() => {
    fetch('http://localhost:4000/api/Playlist',
    {method: "GET"})
      .then((res) => res.json())
      .then((data) => {
        setarPlaylist(data);
        console.log(data);
      })
  }, []);

  const deletarMusica = (id: string) => {
    fetch(`http://localhost:4000/api/Playlist/${id}`,
    {method: "DELETE"})
      .then((res) => {
        if (res.ok) {
          setarPlaylist(playlist.filter(item => item.id !== id));
        } else {
          console.error("Falha ao deletar musica: ", res.status);
        }
      })
  }
  const atualizarMusica = (id: string, musicname: string) => {
    fetch(`http://localhost:4000/api/Playlist/patch${id}`, 
      {method: "PATCH",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({musicname: musicname}),
      })
      .then((res) => {
        if (res.ok) {
          window.location.reload();
          console.log("Música atualizada com succeso!")
        } else {
          console.error("Falha ao editar a música!", res.status);
        }
      })
  }
  
  return (
    <div className="App">
      <header className="App-header">
        <div className="Main-content">
          <h1>Playlist Músicas</h1>
          <p>{playlist.length} Músicas</p>
          {playlist.map((music, index) => (
             <div className="musica" key={index}>
                <a href={music.musiclink}><img className='img-musica' src={music.imglink}/></a>
                <div className="texto">
                <div className="musica-detalhes">
                  <h2>{music.musicname} <img onClick={abrirInput} className='edit-icon' src={editicon}/></h2>
                  {mostrarInput && (
                    <form>
                       <input className="inputField" type="text" placeholder="Digite para editar.."  value={newMusicName}
                       onChange={(e) => setNewMusicName(e.target.value)}/> 
                       <button onClick={(e: React.MouseEvent<HTMLButtonElement>) => {
                          e.preventDefault();
                          atualizarMusica(music.id, newMusicName);
                          }} type="submit" className="submitBtn">✔</button>
                   </form>
                   )}
                  <p>{music.artist}</p>
                </div>
                <a href={music.musiclink}><img src={playicon} className="play-icon"/>
                </a>
                <img src={deleteicon} className="delete-icon" onClick={() =>deletarMusica(music.id)}/>
              </div>
           </div>
         ))}
         
        </div>
        
      </header>
      <h2>Sobre as músicas:</h2>
      <div className="section">
        {playlist.map((music, index) => (
          <div className='musicainfo-container'key={index}>
          <div className='informacao-musica-grid' >
          <img className='img-musica-info' src={music.imglink}/>
            <ul>
           <li><p>{music.artist}</p></li>
           <li><p>Album: {music.album}</p></li>
           <li><p>Genre: {music.genre}</p></li>
           </ul>
          </div>
          </div>
        ))}
        </div>
      <section className="Adicionar-msc">
        <h2>Adicionar mais músicas</h2>
         <FormularioPlaylist/>
      </section>
    </div>
  );
}

export default App;
