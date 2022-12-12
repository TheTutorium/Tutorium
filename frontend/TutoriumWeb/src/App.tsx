import React from "react";
import { Navigate, Route, Routes } from "react-router-dom";

import { Layout } from "./Components/Common/Layout/Layout";
import Course from "./Components/Course/Course";
import Home from "./Components/Home/Home";
import Login from "./Components/Login/Login";
import Meetings from "./Components/Meetings/Meetings";
import Settings from "./Components/Settings/Settings";
import Signup from "./Components/Signup/Singup";
import TutorProfile from "./Components/TutorProfile/TutorProfile";
import Tutors from "./Components/Tutors/Tutors";

export const routes = {
    course: "/tutors/:id/courses/:course_id",
    home: "/",
    login: "/login",
    meetings: "/user/:id/meetings",
    settings: "/settings",
    signup: "/signup",
    tutorProfile: "/tutors/:id",
    tutors: "/tutors",
};

const App = () => {
    const isUserLoggedIn = true;

    return isUserLoggedIn ? (
        <Layout>
            <Routes>
                <Route path={routes.home} element={<Home />} />
                <Route path={routes.course} element={<Course />} />
                <Route path={routes.settings} element={<Settings />} />
                <Route path={routes.meetings} element={<Meetings />} />
                <Route path={routes.tutors} element={<Tutors />} />
                <Route path={routes.tutorProfile} element={<TutorProfile />} />
                <Route path={"*"} element={<Navigate to={routes.home} />} />
            </Routes>
        </Layout>
    ) : (
        <Routes>
            <Route path={routes.login} element={<Login />} />
            <Route path={routes.signup} element={<Signup />} />
            <Route path={"*"} element={<Navigate to={routes.login} />} />
        </Routes>
    );
};

export default App;
