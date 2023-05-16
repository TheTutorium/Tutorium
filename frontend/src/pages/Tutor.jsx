import { useParams } from "react-router-dom";
import { Avatar, AvatarFallback, AvatarImage } from "../components/ui/avatar";
import { useMediaQuery } from "../hooks/use-media-query";
import { Badge } from "../components/ui/badge";
// import { Popover } from "./ui/popover";
import {
  HoverCard,
  HoverCardContent,
  HoverCardTrigger,
} from "../components/ui/hover-card";
import { Button } from "../components/ui/button";
import { CalendarDays } from "lucide-react";
import { Star } from "lucide-react";
// import madalion from lucide-react
import { Medal } from "lucide-react";
import { Link } from "react-router-dom";
import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
} from "../components/ui/card";
import {
  Tabs,
  TabsContent,
  TabsList,
  TabsTrigger,
} from "../components/ui/tabs";
import {
  AlarmClock,
  CalendarClock,
  XCircle,
  Edit,
  StickyNote,
} from "lucide-react";
import moment from "moment";

import {
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogTrigger,
} from "../components/ui/alertDialog";

const tutor = {
  fullName: "Hasan Huseyin Doeganoglullari",
  profileImageUrl: "https://i.pravatar.cc/300",
  description:
    "I Never Ask My Clients to judge me on my winners, I ask them to judge me on my losers because i have so few",
  hours: 10,
  rating: 4.5,
  badges: 5,
  id: 1,
};
function Tutor() {
  const { id } = useParams();
  const isMobile = useMediaQuery("(max-width: 768px)");
  return (
    <div
      className="
      max-w-[1400px]
      mx-auto
      self-stretch
      w-full  
  "
    >
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
              <AvatarFallback
                style={{ fontSize: "1.5rem", borderRadius: "9px" }}
              >
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
              <div className="flex space-x-2">
                {/* 5 times map */}
                {[...Array(2)].map((_, i) => (
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
                            This user completed the CS-202 course at Bilkent
                            with an A+ grade.
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
              </div>
            </div>
            {/* description */}
            <div className="mt-2">
              <p className="text-sm text-muted-foreground italic">
                {tutor.description}
              </p>
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
            <p className="text-sm text-muted-foreground">
              {tutor.badges} badges
            </p>
          </div>
          <div className="flex items-center space-x-2">
            <Star className="h-4 w-4 text-muted-foreground" />
            <p className="text-sm text-muted-foreground">
              {tutor.rating} rating
            </p>
          </div>
        </div>
      </div>
      <div className="">
        <Tabs defaultValue="account" className="p-3 w-full lg:w-full">
          <TabsList className="grid w-full grid-cols-2">
            <TabsTrigger value="account">Courses</TabsTrigger>
            <TabsTrigger value="password">Comments</TabsTrigger>
          </TabsList>
          <TabsContent value="account">
            <div className="space-y-2">
              <Card>
                <CardHeader>
                  <div className="flex flex-col sm:flex-row space-y-2 sm:space-y-0 sm:items-center justify-between p-1">
                    <div className="flex items-center">
                      <AlarmClock className="w-5 h-5 mr-2 inline-block" />
                      <CardTitle>Meeting With John Doe</CardTitle>
                    </div>
                    <div className="flex items-center">
                      <CalendarClock className="w-4 h-4 mr-2 inline-block text-muted-foreground" />
                      <CardDescription>
                        {moment("2023-05-10T12:00:00.000Z").format(
                          "dddd, MMMM Do YYYY, h:mm a"
                        )}
                      </CardDescription>
                    </div>
                  </div>
                </CardHeader>
                <CardContent className="space-y-2">
                  <div className="flex space-x-2">
                    <p className="text-sm text-muted-foreground">Course:</p>
                    <p className=" text-sm text-primary">CS202</p>
                  </div>
                  <div className="flex space-x-2">
                    <p className="text-sm text-muted-foreground">Duration:</p>
                    <p className=" text-sm text-primary">60 minutes</p>
                  </div>
                  <div className="flex space-x-2">
                    <p className="text-sm text-muted-foreground">Notes:</p>
                    <p className=" text-sm text-primary">
                      I want this meeting to be nice
                    </p>
                  </div>
                </CardContent>
                <CardFooter>
                  <div className="w-full flex justify-between">
                    <Button className="mr-2">
                      <Edit className="w-4 h-4 mr-2 inline-block" />
                      Edit Course Material
                    </Button>
                    <Button className="mr-2" variant="destructive">
                      <XCircle className="w-4 h-4 mr-2 inline-block" />
                      <AlertDialog>
                        <AlertDialogTrigger>Cancel meeting</AlertDialogTrigger>
                        <AlertDialogContent>
                          <AlertDialogHeader>
                            <AlertDialogTitle>
                              Are you sure absolutely sure?
                            </AlertDialogTitle>
                            <AlertDialogDescription>
                              This will cancel the meeting and notify the
                              student. You shouldn't do this unless you have a
                              good reason.
                            </AlertDialogDescription>
                          </AlertDialogHeader>
                          <AlertDialogFooter>
                            <AlertDialogCancel>Cancel</AlertDialogCancel>
                            <AlertDialogAction>Continue</AlertDialogAction>
                          </AlertDialogFooter>
                        </AlertDialogContent>
                      </AlertDialog>
                    </Button>
                  </div>
                </CardFooter>
              </Card>
            </div>
          </TabsContent>
          <TabsContent value="password">
            <Card>
              <CardHeader>
                <div className="flex flex-col sm:flex-row space-y-2 sm:space-y-0 sm:items-center justify-between p-1">
                  <div className="flex items-center">
                    <AlarmClock className="w-5 h-5 mr-2 inline-block" />
                    <CardTitle>Meeting With Hasan Huseyin D.</CardTitle>
                  </div>
                  <div className="flex items-center">
                    <CalendarClock className="w-4 h-4 mr-2 inline-block text-muted-foreground" />
                    <CardDescription>
                      {moment("2023-05-05T10:00:00.000Z").format(
                        "dddd, MMMM Do YYYY, h:mm a"
                      )}
                    </CardDescription>
                  </div>
                </div>
              </CardHeader>
              <CardContent className="space-y-2">
                <div className="flex space-x-2">
                  <p className="text-sm text-muted-foreground">Course:</p>
                  <p className=" text-sm text-primary">CS202</p>
                </div>
              </CardContent>
              <CardFooter>
                <div className="w-full flex justify-between">
                  <Button className="mr-2">
                    <StickyNote className="w-4 h-4 mr-2 inline-block" />
                    Course Material
                  </Button>
                  <Button className="mr-2">
                    <Edit className="w-4 h-4 mr-2 inline-block" />
                    Give Feedback
                  </Button>
                </div>
              </CardFooter>
            </Card>
          </TabsContent>
        </Tabs>
      </div>
    </div>
  );
}

export default Tutor;
