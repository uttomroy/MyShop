import Container from '@mui/material/Container';
import Login from '../Components/Login';
import {Routes, Route } from 'react-router-dom';
import { useEffect } from 'react';
import axios from 'axios';

const Body = () => {

    return (
        <Container component="main" sx={{ flexGrow: 1, mt: 2 }}>
            <Routes>
                <Route path='/Login' element={<Login />} />
                <Route path='/' element={<div>Home Page</div>} />
            </Routes>
        </Container>
    );
};

export default Body;
