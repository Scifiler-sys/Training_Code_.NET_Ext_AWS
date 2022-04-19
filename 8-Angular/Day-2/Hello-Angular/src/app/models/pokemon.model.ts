export interface Pokemon
{
    id:number;
    name:string;
    base_experience:number;
    rating?:number; //Trainer rating (from 1 to 5)
    sprites: 
    {
        front_default:string;
    }
}