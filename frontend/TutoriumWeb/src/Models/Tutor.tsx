import User from "./User";

interface Tutor extends User {
    description: string;
    rating: number;
    lecture_hours: number;
}

export default Tutor;
