import React, { useEffect, useState } from "react";
import { Grid, Header, Icon, Image } from "semantic-ui-react";

import CourseElementModel from "../../Models/CourseElement";
import Tutor from "../../Models/Tutor";
import { CourseElement } from "../Common/CourseElement/CourseElement";

const TutorProfile = () => {
    const [active, setActive] = useState(-1);

    const array = courses.slice();
    const chunks = [];
    while (array.length) chunks.push(array.splice(0, 2));

    let pp;
    if (tutor_profile.profilePictureURL === "")
        pp = (
            <Image
                className="pp-style"
                circular
                size="medium"
                src="https://react.semantic-ui.com/images/wireframe/square-image.png"
            />
        );
    else pp = <Image className="pp-style" circular size="medium" src={tutor_profile.profilePictureURL} />;

    return (
        <>
            <Grid>
                <Grid.Row columns={2}>
                    <Grid.Column>
                        <Header as="h1">
                            {tutor_profile.firstName} {tutor_profile.lastName}
                        </Header>
                    </Grid.Column>
                </Grid.Row>
                <Grid.Row columns={2}>
                    <Grid.Column>
                        {pp}
                        <Header as="h2">Statistics</Header>
                        <Header.Content>
                            <p>Lectures: LGS - YKS</p>
                            <p>Rating: {tutor_profile.rating}</p>
                            <p>Total Time Lectured: {tutor_profile.rating}</p>
                        </Header.Content>
                    </Grid.Column>
                    <Grid.Column>
                        <Header as="h2">Description</Header>
                        <p>
                            {tutor_profile.description} <Icon link color="blue" name="edit" />
                        </p>
                    </Grid.Column>
                </Grid.Row>
                <Grid.Row>
                    <Grid.Column>
                        <Header as="h2">Courses</Header>
                    </Grid.Column>
                </Grid.Row>

                {chunks.map((row, in1) => (
                    <Grid.Row key={in1} columns={2}>
                        {row.map((col, in2) => (
                            <Grid.Column key={in1 * 2 + in2}>
                                <div onClick={() => setActive(in1 * 2 + in2)}>
                                    <CourseElement
                                        active={active === in1 * 2 + in2 ? true : false}
                                        description={col.description}
                                        exam={col.exam}
                                        field={col.field}
                                        lecture_name={col.lecture_name}
                                        rate={col.rate}
                                        total_usage={col.total_usage}
                                        materials={col.materials}
                                    />
                                </div>
                            </Grid.Column>
                        ))}
                    </Grid.Row>
                ))}
            </Grid>
        </>
    );
};

const courses: CourseElementModel[] = [
    {
        description: "İnteraktif konu anlatımı ve soru çözümü odaklı çalışma programı.",
        exam: "YKS",
        field: "Matematik",
        lecture_name: "",
        materials: ["Lecture_1.pdf", "Lecture_2.pdf", "Lecture_3.pdf", "Lecture_4.pdf", "Lecture_5.pdf"],
        rate: 8.9,
        total_usage: 43,
    },
    {
        description: "Soru çözümü odaklı çalışma programı.",
        exam: "YKS",
        field: "Fizik",
        lecture_name: "",
        materials: ["Lecture_1.pdf", "Lecture_2.pdf", "Lecture_3.pdf", "Lecture_4.pdf", "Lecture_5.pdf"],
        rate: 9.2,
        total_usage: 26,
    },
    {
        description: "Genel üniversite hayatını anlattığım ve tecrübelerimi aktardığım danışmanlık programı.",
        exam: "YKS",
        field: "",
        lecture_name: "Üniversite Danışmanlık",
        materials: ["Sunum.pdf"],
        rate: 9.2,
        total_usage: 26,
    },
];

const tutor_profile: Tutor = {
    description:
        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa" +
        "strong. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam" +
        "felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede" +
        "justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a," +
        "venenatis vitae, justo. Nullam dictum felis eu pede link mollis pretium. Integer tincidunt. Cras" +
        "dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor" +
        "eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus." +
        "Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi" +
        "vel augue. Curabitur ullamcorper ultricies nisi.",
    email: "Oğuzcan@Pantolon",
    emailVerifiedStatus: true,
    firstName: "Oğuzcan",
    id: 340984095,
    lastName: "Pantolon",
    lecture_hours: 14,
    phone: "+905077297470",
    phoneVerifiedStatus: false,
    profilePictureURL: "",
    rating: 8.7,
};

export default TutorProfile;
