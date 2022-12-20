import React from "react";
import { Header } from "semantic-ui-react";

import Meeting from "../../Models/Meeting";
import { MeetingMessage } from "../Common/MeetingMessage/MeetingMessage";

const user_id = 340984095;

const Meetings = () => {
    return (
        <div>
            <Header as="h1" textAlign="center">
                Upcoming Meetings
            </Header>

            {meetings.map((element, index) => (
                <MeetingMessage
                    key={index}
                    is_lecturer={user_id === element.lecturer_id ? true : false}
                    name={user_id === element.lecturer_id ? element.pupil_name : element.lecturer_name}
                    date={element.date}
                    time={element.time}
                    description={element.description}
                    exam={element.exam}
                    field={element.field}
                    lecture_name={element.lecture_name}
                />
            ))}
        </div>
    );
};

const meetings: Meeting[] = [
    {
        date: "06/12/2022",
        description: "Interaktif konu anlatımı ve soru çözümü odaklı çalışma programı.",
        exam: "YKS",
        field: "Matematik",
        lecture_name: "Lecture 1",
        lecturer_id: 340984095,
        lecturer_name: "Oğuzcan Pantolon",
        pupil_id: 240984495,
        pupil_name: "Mehmet Ali Soykan",
        time: "13:00",
    },
    {
        date: "15/12/2022",
        description: "My experiences on the masters application to universities in United States",
        exam: "",
        field: "",
        lecture_name: "Guide on master's application",
        lecturer_id: 240984495,
        lecturer_name: "Emre Karayurt",
        pupil_id: 340984095,
        pupil_name: "Oğuzcan Pantolon",
        time: "15:00",
    },
    {
        date: "16/12/2022",
        description: "Interaktif konu anlatımı ve soru çözümü odaklı çalışma programı.",
        exam: "YKS",
        field: "Matematik",
        lecture_name: "Lecture 2",
        lecturer_id: 340984095,
        lecturer_name: "Oğuzcan Pantolon",
        pupil_id: 240984495,
        pupil_name: "Mehmet Ali Soykan",
        time: "11:30",
    },
];

export default Meetings;
