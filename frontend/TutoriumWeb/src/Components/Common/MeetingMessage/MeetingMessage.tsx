import "./MeetingMessage.css";

import React, { FunctionComponent } from "react";
import { Button, Container, Grid, Message } from "semantic-ui-react";

interface Props {
    is_lecturer: boolean;
    name: string;
    date: string;
    time: string;
    description: string;
    exam: string;
    field: string;
    lecture_name: string;
}

export const MeetingMessage: FunctionComponent<Props> = ({
    is_lecturer,
    name,
    date,
    time,
    description,
    exam,
    field,
    lecture_name,
}) => {
    return (
        <div>
            <Message className="message-style" color={is_lecturer ? "brown" : "blue"}>
                <Grid>
                    <Grid.Row className="colum-row-style" columns={2}>
                        <Grid.Column>
                            <Container textAlign="left">
                                <strong>Upcoming Lecture {is_lecturer ? "with " + name : "by " + name}</strong>
                            </Container>
                        </Grid.Column>
                        <Grid.Column>
                            <Container textAlign="right">
                                <strong>{date}</strong>
                            </Container>
                        </Grid.Column>
                    </Grid.Row>
                    <Grid.Row className="colum-row-style" columns={2}>
                        <Grid.Column>
                            <Container textAlign="left">
                                <p>
                                    {exam === ""
                                        ? lecture_name
                                        : field === ""
                                        ? exam + " - " + lecture_name
                                        : exam + " - " + field}
                                </p>
                            </Container>
                        </Grid.Column>
                        <Grid.Column>
                            <Container textAlign="right">
                                <strong>{time}</strong>
                            </Container>
                        </Grid.Column>
                    </Grid.Row>
                    <Grid.Row className="colum-row-style">
                        <p className="test">{description}</p>
                    </Grid.Row>
                    <Grid.Row className="colum-row-style2">
                        <div className="right floated column">
                            <Button compact className="button-style" color="blue">
                                Join
                            </Button>
                            <Button compact className="button-style" color="red">
                                Cancel
                            </Button>
                        </div>
                    </Grid.Row>
                </Grid>
            </Message>
        </div>
    );
};
