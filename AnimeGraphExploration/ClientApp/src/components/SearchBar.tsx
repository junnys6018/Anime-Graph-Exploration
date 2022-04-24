import { TextField } from "@mui/material"

export default function SearchBar() {
  const borderRadius = "30px"

  return (
    <div>
      <TextField
        placeholder="Search"
        className="w-96"
        sx={{ backgroundColor: "white", borderRadius, "& fieldset": { borderRadius } }}
      ></TextField>
    </div>
  )
}
