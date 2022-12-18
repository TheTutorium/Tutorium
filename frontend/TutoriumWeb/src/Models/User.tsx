interface User {
    id: number;
    email: string;
    emailVerifiedStatus: boolean;
    firstName: string;
    lastName: string;
    phone: string;
    phoneVerifiedStatus: boolean;
    profilePictureURL: string;
}

export default User;
