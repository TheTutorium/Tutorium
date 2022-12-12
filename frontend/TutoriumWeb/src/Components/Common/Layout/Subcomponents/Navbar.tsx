import "./Navbar.css";

import React, { FunctionComponent } from "react";
import { NavLink } from "react-router-dom";
import { Image, Menu } from "semantic-ui-react";

export const Navbar: FunctionComponent = () => {
    return (
        <Menu className="nav-menu" fixed="top" inverted size="small">
            <Menu.Item as={NavLink} to="/">
                <Image size="mini" src="favicon.ico" />
            </Menu.Item>
        </Menu>
    );
};
