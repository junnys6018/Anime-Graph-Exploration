import SearchBar from "./components/SearchBar"
import Card from "./components/Card"
import "./assets/css/App.css"

export default function App() {
  return (
    <div className="w-full h-full">
      <div className="title-container text-center flex flex-row">
        <div className="m-auto text-white text-4xl">
          <div className="p-4">Anime Explorer</div>
          <SearchBar></SearchBar>
        </div>
      </div>
      <Card
        image="https://api-cdn.myanimelist.net/images/anime/1517/100633l.jpg"
        id={38524}
        title="Shingeki no Kyojin Season 3 Part 2"
      />
    </div>
  )
}
