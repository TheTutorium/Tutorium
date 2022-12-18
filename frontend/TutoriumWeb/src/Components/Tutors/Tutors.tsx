import React from "react";
import { useEffect, useState } from "react";
import { Button, Dropdown, Grid, Header, Input } from "semantic-ui-react";

import Tutor from "../../Models/User";
import { TutorList } from "../Common/TutorList/TutorList";

const Tutors = () => {
    const [count, setCount] = useState(1);

    let subset = tutors.slice(0, 8 * count);
    useEffect(() => {
        subset = tutors.slice(0, 8 * count);
    });

    const tutors_component = (
        <>
            <Header as="h1" textAlign="center">
                Tutors
            </Header>
            <TutorList tutors={subset} />
        </>
    );

    const search_component = (
        <>
            <Header as="h1" textAlign="center">
                Search
            </Header>
            <Grid>
                <Grid.Column width={4}>
                    <Input fluid placeholder="Name" />
                </Grid.Column>
                <Grid.Column width={4}>
                    <Input fluid placeholder="University" />
                </Grid.Column>
                <Grid.Column width={3}>
                    <Dropdown fluid placeholder="Exam" options={exam_options} clearable selection />
                </Grid.Column>
                <Grid.Column width={3}>
                    <Dropdown fluid placeholder="Field" options={field_options} clearable selection />
                </Grid.Column>
                <Grid.Column width={2}>
                    <Button fluid primary>
                        Search
                    </Button>
                </Grid.Column>
            </Grid>
        </>
    );

    if (8 * count < tutors.length)
        return (
            <div>
                {search_component}
                {tutors_component}
                <Header
                    className="show-more"
                    as="h3"
                    textAlign="center"
                    color="blue"
                    onClick={() => setCount(count + 1)}
                >
                    Show More
                </Header>
            </div>
        );
    else
        return (
            <div>
                {search_component}
                {tutors_component}
            </div>
        );
};

const exam_options = [
    { key: 1, text: "YKS", value: 1 },
    { key: 2, text: "LGS", value: 2 },
    { key: 3, text: "KPSS", value: 3 },
];

const field_options = [
    { key: 1, text: "Matematik", value: 1 },
    { key: 2, text: "Fizik", value: 2 },
];

const tutors: Tutor[] = [
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

export default Tutors;
