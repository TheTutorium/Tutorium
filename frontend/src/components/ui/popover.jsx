import React from "react";
import PropTypes from "prop-types";
import * as PopoverPrimitive from "@radix-ui/react-popover";

import { cn } from "../../utils/utils";
const Popover = PopoverPrimitive.Root;
const PopoverTrigger = PopoverPrimitive.Trigger;

const PopoverContent = React.forwardRef((props, ref) => {
  const { className, align = "center", sideOffset = 4, ...rest } = props;

  return (
    <PopoverPrimitive.Portal>
      <PopoverPrimitive.Content
        ref={ref}
        align={align}
        sideOffset={sideOffset}
        className={cn(
          "z-50 w-72 rounded-md border bg-popover p-4 text-popover-foreground shadow-md outline-none animate-in data-[side=bottom]:slide-in-from-top-2 data-[side=left]:slide-in-from-right-2 data-[side=right]:slide-in-from-left-2 data-[side=top]:slide-in-from-bottom-2",
          className
        )}
        {...rest}
      />
    </PopoverPrimitive.Portal>
  );
});

PopoverContent.displayName = "PopoverContent";

PopoverContent.propTypes = {
  className: PropTypes.string,
  align: PropTypes.string,
  sideOffset: PropTypes.number,
};

export { Popover, PopoverTrigger, PopoverContent };
