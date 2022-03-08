export interface Pokemon
{
    id:number;
    name:string;
    base_experience:number;
    sprites: 
    {
        front_default:string;
    },
    pokeId?: number,
    level?: number,
    attack?: number,
    defense?: number,
    health?: number,
    speed?: number,
    type?: string
}