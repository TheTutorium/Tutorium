import { useEffect, useState } from "react";
import { TutorCard } from "../components/TutorCard";
import { Button } from "../components/ui/button";
import { useAuth, useUser } from "@clerk/clerk-react";
import { useUserType } from "../utils/UserTypeContext";

export function Dashboard() {
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
  const { getToken } = useAuth();
  const { isTutor, typeLoading } = useUserType();
  return (
    <div
      className="
        max-w-[1400px]
        mx-auto
        self-stretch
        w-full  
    "
    >
      {typeLoading ? (
        <div>Loading...</div>
      ) : (
        <>
          <div className="flex flex-col justify-center w-full h-full md:px-5 py-5">
            <div className="w-full border rounded-md mb-2">
              Some kind of filter #TODO
            </div>
            {isTutor ? (
              <div className="w-full border rounded-md mb-2">
                <Button variant="primary" className="w-full">
                  Create a new meeting
                </Button>
              </div>
            ) : (
              <>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <TutorCard tutor={tutor} />
                  <TutorCard tutor={tutor} />
                  <TutorCard tutor={tutor} />
                  <TutorCard tutor={tutor} />
                  <TutorCard tutor={tutor} />
                  <TutorCard tutor={tutor} />
                  <TutorCard tutor={tutor} />
                  <TutorCard tutor={tutor} />
                </div>
                <Button
                  className="mt-5"
                  variant="link"
                  onClick={async () => {
                    // console.log user id
                    console.log(user.id);

                    const token = await getToken();
                    fetch("http://127.0.0.1:8000/", {
                      method: "POST",
                      headers: {
                        "Content-Type": "application/json",
                        Authorization: `Bearer ${token}`,
                      },
                      body: JSON.stringify({
                        name: "John Doe",
                      }),
                    }).then((res) => console.log(res));
                  }}
                >
                  Load More
                </Button>
              </>
            )}
          </div>
        </>
      )}
    </div>
  );
}
