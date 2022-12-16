import React, { FunctionComponent } from "react";
import { Link } from "react-router-dom";
import { Header, Image } from "semantic-ui-react";

interface Props {
    profilePictureURL: string;
    name: string;
    surname: string;
}

export const TutorMiniProfile: FunctionComponent<Props> = ({ profilePictureURL, name, surname }) => {
    let pp;
    if (profilePictureURL === "")
        pp = (
            <Image
                centered
                circular
                size="small"
                src="https://react.semantic-ui.com/images/wireframe/square-image.png"
            />
        );
    else pp = <Image centered circular size="small" src={profilePictureURL} />;

    return (
        <Link to="/tutors/:id" className="center aligned content">
            {pp}
            <Header as="h4" textAlign="center">
                <Header.Content>
                    {name} {surname}
                </Header.Content>
            </Header>
        </Link>
    );
};
