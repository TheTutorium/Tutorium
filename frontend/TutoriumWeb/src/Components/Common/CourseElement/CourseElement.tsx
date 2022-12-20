import React, { FunctionComponent } from "react";
import { Button, Grid, Header, Message } from "semantic-ui-react";

interface Props {
    active: boolean;
    description: string;
    exam: string;
    field: string;
    lecture_name: string;
    rate: number;
    total_usage: number;
    materials: string[];
}

export const CourseElement: FunctionComponent<Props> = ({
    active,
    description,
    exam,
    field,
    lecture_name,
    rate,
    total_usage,
    materials,
}) => {
    if (materials.length === 0) materials = ["No material"];
    if (active)
        return (
            <div>
                <Message className="message-course-style" color="brown">
                    <strong>
                        {exam === "" ? lecture_name : field === "" ? exam + " - " + lecture_name : exam + " - " + field}
                    </strong>
                    <p>{description}</p>
                    <Grid>
                        <Grid.Row columns={2}>
                            <Grid.Column>
                                <strong>Matrials</strong>
                                {materials.map((s, i) => (
                                    <p key={i}>{s}</p>
                                ))}
                            </Grid.Column>
                            <Grid.Column>
                                <strong>Stats</strong>
                                <p>Total Usage: {total_usage} people</p>
                                <p>Rate: {rate}/10</p>
                                <Button compact floated="right" color="blue">
                                    Schedule
                                </Button>
                            </Grid.Column>
                        </Grid.Row>
                    </Grid>
                </Message>
            </div>
        );
    else
        return (
            <div>
                <Message className="message-course-style" color="brown">
                    <strong>
                        {exam === "" ? lecture_name : field === "" ? exam + " - " + lecture_name : exam + " - " + field}
                    </strong>
                    <p>{description}</p>
                </Message>
            </div>
        );
};
