interface CardProps {
  title: string
  image: string
  id: number
}

export default function Card(props: CardProps) {
  return (
    <a
      href={`https://myanimelist.net/anime/${props.id}/`}
      target="_blank"
      rel="noopener noreferrer"
      className="w-36 rounded-xl bg-blue-100 hover:bg-blue-200 transition-colors inline-block"
    >
      <img src={props.image} className="rounded-t-xl"></img>
      <h3 className="font-medium py-2 px-3 truncate" title={props.title}>
        {props.title}
      </h3>
    </a>
  )
}
