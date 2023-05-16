import { useEffect } from "react";

const useComponentDidMount = (callback) => {
  useEffect(() => {
    callback();
  }, []); // Empty array ensures this runs only on mount and not on updates
};

export default useComponentDidMount;
