import { Button } from "../components/ui/button";
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

export function Meetings() {
  return (
    <div
      className="
        max-w-[1400px]
        mx-auto
        self-stretch
        w-full  
        flex
        justify-center
    "
    >
      <Tabs defaultValue="account" className="m-3 w-full lg:w-[800px]">
        <TabsList className="grid w-full grid-cols-2">
          <TabsTrigger value="account">Incoming Meetings</TabsTrigger>
          <TabsTrigger value="password">Passed Meetings</TabsTrigger>
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
                            This will cancel the meeting and notify the student.
                            You shouldn't do this unless you have a good reason.
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
  );
}
