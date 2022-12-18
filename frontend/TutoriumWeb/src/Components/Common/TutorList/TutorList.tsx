import React, { FunctionComponent } from "react";
import { Grid } from "semantic-ui-react";

import Tutor from "../../../Models/User";
import { TutorMiniProfile } from "../TutorMiniProfile/TutorMiniProfile";

interface Props {
    tutors: Tutor[];
}

export const TutorList: FunctionComponent<Props> = ({ tutors }) => {
    const array = tutors.slice();
    const chunks = [];
    while (array.length) chunks.push(array.splice(0, 4));

    return (
        <Grid centered relaxed columns={4}>
            {chunks.map((row, in1) => (
                <Grid.Row key={in1}>
                    {row.map((col, in2) => (
                        <Grid.Column key={in1 * 4 + in2}>
                            <TutorMiniProfile
                                key={in1 * 4 + in2}
                                profilePictureURL={col.profilePictureURL}
                                name={col.firstName}
                                surname={col.lastName}
                            />
                        </Grid.Column>
                    ))}
                </Grid.Row>
            ))}
        </Grid>
    );
};
