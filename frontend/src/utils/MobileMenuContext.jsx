import { createContext, useContext, useState } from "react";

import PropTypes from "prop-types";

const MobileMenuContext = createContext();

export const useMobileMenu = () => useContext(MobileMenuContext);

export const MobileMenuProvider = ({ children }) => {
  const [isCollapsed, setIsCollapsed] = useState(true);

  return (
    <MobileMenuContext.Provider value={{ isCollapsed, setIsCollapsed }}>
      {children}
    </MobileMenuContext.Provider>
  );
};

MobileMenuProvider.propTypes = {
  children: PropTypes.node.isRequired,
};
