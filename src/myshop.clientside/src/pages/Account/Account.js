import React from "react";
import { Outlet } from "react-router-dom";

export default function Account() {
  return (
    <div>
        MY Account page
        <Outlet></Outlet>
    </div>
  );
}
