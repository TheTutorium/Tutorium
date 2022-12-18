import "./Home.css";

import React from "react";
import { Link } from "react-router-dom";
import { Header } from "semantic-ui-react";

import Tutor from "../../Models/User";
import { TutorList } from "../Common/TutorList/TutorList";

const Home = () => {
    return (
        <div>
            <Header as="h1" textAlign="center">
                About
            </Header>
            <p>
                Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa
                strong. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam
                felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede
                justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a,
                venenatis vitae, justo. Nullam dictum felis eu pede link mollis pretium. Integer tincidunt. Cras
                dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor
                eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus.
                Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi
                vel augue. Curabitur ullamcorper ultricies nisi.
            </p>

            <Header as="h1" textAlign="center">
                Tutors
            </Header>
            <TutorList tutors={rising_tutors} />
            <Link to="/tutors" className="link">
                <Header className="show-more" as="h3" textAlign="center" color="blue">
                    Show More
                </Header>
            </Link>
        </div>
    );
};

const rising_tutors: Tutor[] = [
    {
        email: "Oğuzcan@Pantolon",
        emailVerifiedStatus: true,
        firstName: "Oğuzcan",
        id: 340984095,
        lastName: "Pantolon",
        phone: "kkek",
        phoneVerifiedStatus: false,
        profilePictureURL: "",
    },
    {
        email: "Oğuzhan@Özçelik",
        emailVerifiedStatus: true,
        firstName: "Oğuzhan",
        id: 340984095,
        lastName: "Özçelik",
        phone: "kkek",
        phoneVerifiedStatus: false,
        profilePictureURL: "",
    },
    {
        email: "Ali@Aydoğmuş",
        emailVerifiedStatus: true,
        firstName: "Ali",
        id: 340984095,
        lastName: "Aydoğmuş",
        phone: "kkek",
        phoneVerifiedStatus: false,
        profilePictureURL: "",
    },
    {
        email: "Barış@Yörük",
        emailVerifiedStatus: true,
        firstName: "Barış Ogün",
        id: 340984095,
        lastName: "Yörük",
        phone: "kkek",
        phoneVerifiedStatus: false,
        profilePictureURL: "",
    },
    {
        email: "Yusuf@Uyar",
        emailVerifiedStatus: true,
        firstName: "Yusuf",
        id: 340984095,
        lastName: "Uyar",
        phone: "kkek",
        phoneVerifiedStatus: false,
        profilePictureURL: "",
    },
    {
        email: "Çağrı@Durgut",
        emailVerifiedStatus: true,
        firstName: "Çağrı",
        id: 340984095,
        lastName: "Durgut",
        phone: "kkek",
        phoneVerifiedStatus: false,
        profilePictureURL: "",
    },
    {
        email: "Özgür@Demir",
        emailVerifiedStatus: true,
        firstName: "Halil Özgür",
        id: 340984095,
        lastName: "Demir",
        phone: "kkek",
        phoneVerifiedStatus: false,
        profilePictureURL: "",
    },
    {
        email: "Aybala@Karakaya",
        emailVerifiedStatus: true,
        firstName: "Aybala",
        id: 340984095,
        lastName: "Karakaya",
        phone: "kkek",
        phoneVerifiedStatus: false,
        profilePictureURL: "",
    },
];

export default Home;
