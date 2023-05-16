import * as React from "react";
// import { siteConfig } from "@/config/site"
import { cn } from "../../utils/utils";
import { Icons } from "../../utils/Icons";
import { MobileNav } from "./MobileNav";
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
  NavigationMenuTrigger,
} from "../ui/navigation-menu";
import { Button } from "../ui/button";
import { Link } from "react-router-dom";
import { Avatar, AvatarFallback, AvatarImage } from "../ui/avatar";
import { useClerk } from "@clerk/clerk-react";

/* eslint-disable react/prop-types */
export default function Navbar({ items, children }) {
  const [showMobileMenu, setShowMobileMenu] = React.useState(false);

  // if there is a signed user set this const to true
  const { user } = useClerk();

  return (
    <div className="flex gap-6 md:gap-10">
      <div className="hidden md:flex">
        <Link to="/" className="items-center space-x-2 flex mr-5">
          <Avatar>
            <AvatarImage src={"/logo.svg"} alt={"Tutorium"} />
            <AvatarFallback>C</AvatarFallback>
          </Avatar>
          <span className="hidden font-bold sm:inline-block">Tutorium</span>
        </Link>

        <NavigationMenu>
          <NavigationMenuList>
            <NavigationMenuItem>
              <NavigationMenuTrigger>Info</NavigationMenuTrigger>
              <NavigationMenuContent>
                <ul className="grid gap-3 p-6 md:w-[400px] lg:w-[500px] lg:grid-cols-[.75fr_1fr]">
                  <li className="row-span-4">
                    <NavigationMenuLink asChild>
                      <Link
                        className="pb-12 flex h-full w-full select-none flex-col justify-end rounded-md bg-gradient-to-b from-muted/50 to-muted p-6 no-underline outline-none focus:shadow-md"
                        to="/"
                      >
                        <Icons.logo className="h-6 w-6" />
                        <div className="mb-2 mt-4 text-lg font-medium">
                          Tutorium
                        </div>
                        <p className="text-sm leading-tight text-muted-foreground">
                          Reinventing the peer-to-peer learning experience one
                          grasshoppper at a time.
                        </p>
                      </Link>
                    </NavigationMenuLink>
                  </li>
                  <ListItem to="/#about" title="About">
                    Learn about Tutorium and its mission, vision and values
                  </ListItem>
                  <ListItem to="/team" title="Team">
                    Meet the team behind Tutorium
                  </ListItem>
                  <ListItem to="/stack" title="Tech Stack">
                    Get a sense of the tech stack we use
                  </ListItem>
                  <ListItem to="/contact" title="Contact">
                    Reach us if you have any questions, feedback or just want to
                    say hi
                  </ListItem>
                </ul>
              </NavigationMenuContent>
            </NavigationMenuItem>
            <NavigationMenuItem>
              <NavigationMenuTrigger>CS491/2</NavigationMenuTrigger>
              <NavigationMenuContent>
                <div>
                  <h3 className="my-2 text-lg font-medium text-center">
                    CS491/2
                  </h3>
                </div>
                <ul className="grid w-[400px] gap-3 p-4 md:w-[500px] md:grid-cols-2 lg:w-[600px] ">
                  {components.map((component) => (
                    <ListItem
                      key={component.title}
                      title={component.title}
                      to={component.href}
                    >
                      {component.description}
                    </ListItem>
                  ))}
                </ul>
              </NavigationMenuContent>
            </NavigationMenuItem>
            <NavigationMenuItem>
              <Link to={"/dashboard"}>
                <Button variant={"ghost"}>Dashboard</Button>
              </Link>
            </NavigationMenuItem>
            {user && (
              <>
                <NavigationMenuItem>
                  <Link to={"/meetings"}>
                    <Button variant={"ghost"}>Meetings</Button>
                  </Link>
                </NavigationMenuItem>
              </>
            )}

            <NavigationMenuItem>
              <Link to={"/canvas"}>
                <Button variant={"ghost"}>Canvas</Button>
              </Link>
            </NavigationMenuItem>
          </NavigationMenuList>
        </NavigationMenu>
      </div>
      <button
        className="flex items-center space-x-2 md:hidden"
        onClick={() => setShowMobileMenu(!showMobileMenu)}
      >
        {showMobileMenu ? <Icons.close /> : <Icons.menu />}
        <span className="font-bold">Tutorium</span>
      </button>
      {showMobileMenu && items && (
        <MobileNav
          showMobileMenu={showMobileMenu}
          setShowMobileMenu={setShowMobileMenu}
        >
          {children}
        </MobileNav>
      )}
    </div>
  );
}

const components = [
  {
    title: "Desgin Report",
    href: "/files/cs491-design-report.pdf",
    description:
      "Design report of the project. It includes the design decisions, the design process and the design artifacts.",
  },
  {
    title: "Detailed Design Report",
    href: "/files/cs491-detailed-design-report.pdf",
    description:
      "Detailed design report of the project. It includes the detailed design decisions, the detailed design process and the detailed design artifacts.",
  },
  {
    title: "Final Report",
    href: "/files/cs492-final-report.pdf",
    description:
      "Displays an indicator showing the completion progress of a task, typically displayed as a progress bar.",
  },
];

const ListItem = React.forwardRef(
  ({ className, title, children, ...props }, ref) => {
    return (
      <li>
        <NavigationMenuLink asChild>
          <Link
            ref={ref}
            className={cn(
              "block select-none space-y-1 rounded-md p-3 leading-none no-underline outline-none transition-colors hover:bg-accent hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground",
              className
            )}
            {...props}
          >
            <div className="text-sm font-medium leading-none">{title}</div>
            <p className="line-clamp-2 text-sm leading-snug text-muted-foreground">
              {children}
            </p>
          </Link>
        </NavigationMenuLink>
      </li>
    );
  }
);
ListItem.displayName = "ListItem";
