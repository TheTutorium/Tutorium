import { cn } from "../utils/utils";
import { Icons } from "../utils/Icons";
import { ModeToggle } from "../utils/toggle";
import { Link } from "react-router-dom";

export function Footer({ className }) {
  return (
    <footer className={cn(className)}>
      <div className="container flex flex-col items-center justify-between gap-4 py-10 md:h-24 md:flex-row md:py-0">
        <div className="flex flex-col items-center gap-4 px-8 md:flex-row md:gap-2 md:px-0">
          <Icons.logo />
          <p className="text-center text-sm leading-loose md:text-left">
            Built by{" "}
            <Link
              to="/team"
              // target="_blank"
              rel="noreferrer"
              className="font-medium underline underline-offset-4"
            >
              Bilkent Students
            </Link>{" "}
            with ❤️. The source code is available on{" "}
            <Link
              //   href={siteConfig.links.github}
              target="_blank"
              rel="noreferrer"
              className="font-medium underline underline-offset-4"
            >
              GitHub
            </Link>
            .
          </p>
        </div>
        <ModeToggle />
      </div>
    </footer>
  );
}
