import "./Layout.css";

import React, { FunctionComponent, ReactNode } from "react";
import { Segment, Sticky } from "semantic-ui-react";

import { Navbar } from "./Subcomponents/Navbar";

interface Props {
    children: ReactNode;
}

export const Layout: FunctionComponent<Props> = ({ children }) => {
    return (
        <div>
            <Sticky>
                <Navbar />
            </Sticky>
            <Segment basic>
                <main className={"layout-main"}>{children}</main>
            </Segment>
        </div>
    );
};
