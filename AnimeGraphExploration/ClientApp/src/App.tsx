import { useState } from "react"
import SearchBar from "./components/SearchBar"
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
    </div>
  )
}
