import "./Layout.css";

import React, { FunctionComponent, ReactNode } from "react";

import { Navbar } from "./Subcomponents/Navbar";

interface Props {
    children: ReactNode;
}

export const Layout: FunctionComponent<Props> = ({ children }) => {
    return (
        <>
            <Navbar />
            <main className={"layout-main"}>{children}</main>
        </>
    );
};
