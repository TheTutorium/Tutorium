import { Avatar, AvatarFallback, AvatarImage } from "./ui/avatar";
import { useMediaQuery } from "../hooks/use-media-query";
import { Badge } from "./ui/badge";
import { Popover } from "./ui/popover";
import { HoverCard, HoverCardContent, HoverCardTrigger } from "./ui/hover-card";
import { Button } from "./ui/button";
import { CalendarDays } from "lucide-react";
import { Star } from "lucide-react";
// import madalion from lucide-react
import { Medal } from "lucide-react";
import { Link } from "react-router-dom";
/* eslint-disable react/prop-types */
export function TutorCard({ tutor }) {
  const isMobile = useMediaQuery("(max-width: 768px)");
  return (
    <div className="rounded-lg border bg-card text-card-foreground shadow-sm w-4/5 md:w-full lg:max-w-none mx-auto my-auto flex flex-col lg:justify-start">
      <div className="flex flex-col lg:flex-row space-y-1.5 lg:space-y-0 p-3 md:p-5 pb-1 md:pb-1 w-full">
        <div className="flex justify-center">
          <Avatar
            style={{
              width: isMobile ? "120px" : "160px",
              height: isMobile ? "120px" : "160px",
              borderRadius: "9px",
            }}
          >
            <AvatarImage src={tutor.profileImageUrl} alt={tutor.fullName} />
            <AvatarFallback style={{ fontSize: "1.5rem", borderRadius: "9px" }}>
              {/* {user.fullName[0].toUpperCase()} */}
              {/* take the first letter from first two names */}
              {tutor.fullName
                .split(" ")
                .map((name) => name[0])
                .join("")
                .toUpperCase()}
            </AvatarFallback>
          </Avatar>
        </div>
        <div className="ml-3 lg:w-1/2 xl:w-3/5">
          <h3 className="text-lg font-semibold">
            {tutor.fullName.split(" ").slice(0, -1).join(" ") +
              " " +
              tutor.fullName.split(" ").slice(-1)[0][0] +
              "."}
          </h3>
          <div className="">
            <HorizontalScroll>
              {/* 5 times map */}
              {[...Array(4)].map((_, i) => (
                <HoverCard key={i}>
                  <HoverCardTrigger asChild>
                    <div className={"cursor-pointer"}>
                      <Badge>CS202/A-</Badge>
                    </div>
                  </HoverCardTrigger>
                  <HoverCardContent className="w-80">
                    <div className="flex justify-between space-x-4">
                      <Avatar>
                        <AvatarImage src="https://upload.wikimedia.org/wikipedia/en/thumb/5/5e/Bilkent_University_Crest.svg/316px-Bilkent_University_Crest.svg.png?20210813000718" />
                        <AvatarFallback>BU</AvatarFallback>
                      </Avatar>
                      <div className="space-y-1">
                        <h4 className="text-sm font-semibold">CS-202/A+</h4>
                        <p className="text-sm">
                          This user completed the CS-202 course at Bilkent with
                          an A+ grade.
                        </p>
                        <div className="flex items-center pt-2">
                          <CalendarDays className="mr-2 h-4 w-4 opacity-70" />{" "}
                          <span className="text-xs text-muted-foreground">
                            December 2021
                          </span>
                        </div>
                      </div>
                    </div>
                  </HoverCardContent>
                </HoverCard>
              ))}
            </HorizontalScroll>
          </div>
          {/* description */}
          <div className="mt-2">
            <p className="text-sm text-muted-foreground italic">
              {tutor.description}
            </p>
          </div>
          {/* prifle */}
          <div className="mt-2 flex justify-center">
            <Button variant="link">
              <Link to={`/tutors/${tutor.id}`}>View Profile</Link>
            </Button>
          </div>
        </div>
      </div>

      <div className="flex space-x-2 justify-center p-3 ">
        <div className="flex items-center space-x-2">
          <CalendarDays className="h-4 w-4 text-muted-foreground" />
          <p className="text-sm text-muted-foreground">{tutor.hours} hours</p>
        </div>
        <div className="flex items-center space-x-2">
          <Medal className="h-4 w-4 text-muted-foreground" />
          <p className="text-sm text-muted-foreground">{tutor.badges} badges</p>
        </div>
        <div className="flex items-center space-x-2">
          <Star className="h-4 w-4 text-muted-foreground" />
          <p className="text-sm text-muted-foreground">{tutor.rating} rating</p>
        </div>
      </div>
    </div>
  );
}

const HorizontalScroll = ({ children }) => {
  const handleWheel = (e) => {
    e.preventDefault();
    e.stopPropagation();
    const container = e.currentTarget;
    const sensitivity = 50; // Adjust this value to control scrolling speed

    container.scrollLeft += (e.deltaY * sensitivity) / 100;
  };

  return (
    <div
      className="horizontal-scroll-container flex overflow-x-auto space-x-3 p-1 pl-0 max-w-max "
      // instead of scroll, lay the overflowed items in another row (flex-wrap)
      // className="horizontal-scroll-container flex flex-wrap space-x-3 p-1 pl-0 max-w-max "
      onWheel={handleWheel}
      style={{
        overscrollBehavior: "contain",
      }}
    >
      {children}
    </div>
  );
};
