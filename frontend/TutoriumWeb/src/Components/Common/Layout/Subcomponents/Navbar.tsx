import "./Navbar.css";

import React, { FunctionComponent } from "react";
import { NavLink } from "react-router-dom";
import { Button, Menu } from "semantic-ui-react";

export const Navbar: FunctionComponent = () => {
    return (
        <Menu pointing secondary className="nav-menu" size="large" attached="top">
            <Menu.Menu className="navigator-left-menu" position="left">
                <Menu.Item>
                    <strong>Tutorium</strong>
                </Menu.Item>
                <Menu.Item as={NavLink} to="/">
                    Home
                </Menu.Item>
                <Menu.Item as={NavLink} to="/tutors">
                    Tutors
                </Menu.Item>
                <Menu.Item as={NavLink} to="/user/:id/meetings">
                    Meetings
                </Menu.Item>
            </Menu.Menu>
            <Menu.Menu className="navigator-right-menu" position="right">
                <Menu.Item>
                    <Button primary>Log in</Button>
                </Menu.Item>
                <Menu.Item>
                    <Button primary>Sign up</Button>
                </Menu.Item>
            </Menu.Menu>
        </Menu>
    );
};
