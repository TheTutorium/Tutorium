import * as React from "react";
import { cn } from "../../utils/utils";
import { useLockBody } from "../../hooks/use-lock-body";
import { Icons } from "../../utils/Icons";
import { Link } from "react-router-dom";
import { useClerk } from "@clerk/clerk-react";

export function MobileNav({ children, showMobileMenu, setShowMobileMenu }) {
  useLockBody();
  const { user } = useClerk();
  return (
    <div
      className={cn(
        "fixed inset-0 top-16 z-50 grid h-[calc(100vh-4rem)] grid-flow-row auto-rows-max overflow-auto p-6 pb-32 shadow-md animate-in slide-in-from-bottom-80 md:hidden"
      )}
    >
      <div className="relative z-20 grid gap-6 rounded-md bg-popover p-4 text-popover-foreground shadow-md">
        <Link to="/" className="flex items-center space-x-2">
          <Icons.logo />
          <span className="font-bold">Tutorium</span>
        </Link>
        <nav className="grid grid-flow-row auto-rows-max text-sm">
          <Link
            to={"/dashboard"}
            onClick={() => setShowMobileMenu(false)}
            className={cn(
              "flex w-full items-center rounded-md p-2 text-sm font-medium hover:underline"
            )}
          >
            Dashboard
          </Link>
          {user && (
            <Link
              to={"/meetings"}
              onClick={() => setShowMobileMenu(false)}
              className={cn(
                "flex w-full items-center rounded-md p-2 text-sm font-medium hover:underline"
              )}
            >
              Meetings
            </Link>
          )}
          <Link
            to={"/#about"}
            onClick={() => setShowMobileMenu(false)}
            className={cn(
              "flex w-full items-center rounded-md p-2 text-sm font-medium hover:underline"
            )}
          >
            About
          </Link>
          <Link
            to={"/team"}
            onClick={() => setShowMobileMenu(false)}
            className={cn(
              "flex w-full items-center rounded-md p-2 text-sm font-medium hover:underline"
            )}
          >
            Team
          </Link>
          <Link
            to={"/contact"}
            onClick={() => setShowMobileMenu(false)}
            className={cn(
              "flex w-full items-center rounded-md p-2 text-sm font-medium hover:underline"
            )}
          >
            Contact
          </Link>
          <Link
            to={"/stack"}
            onClick={() => setShowMobileMenu(false)}
            className={cn(
              "flex w-full items-center rounded-md p-2 text-sm font-medium hover:underline"
            )}
          >
            Stack
          </Link>
        </nav>
        {children}
      </div>
    </div>
  );
}
