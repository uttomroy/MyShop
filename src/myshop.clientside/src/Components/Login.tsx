import React, { useEffect, useState } from 'react';
import TextField from '@mui/material/TextField';
import {
    Avatar,
    Box,
    Button,
    Checkbox,
    FormControlLabel,
    IconButton,
    InputAdornment,
    Link,
    Stack
} from '@mui/material';
import RemoveRedEyeIcon from '@mui/icons-material/RemoveRedEye';
import VisibilityOffIcon from '@mui/icons-material/VisibilityOff';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined'
import axios from 'axios';
import config from '../Config/config';


const Login = () => {
    const [showPassword, setShowPassword] = useState(false);

    useEffect(() => {
        axios.post(config.baseUrl + '/api/Account/Get')
            .then(response => {
                console.log(response)
            })
            .catch(error => {
                console.error(error);
            });
    }, [])

    return (
        <Box sx={{
            margin: 'auto', alignItems: 'center', display: 'flex',
            flexDirection: 'column'
        }}>
            <Avatar sx={{ m: 1, bgcolor: 'secondary.main' }}>
                <LockOutlinedIcon />
            </Avatar>
            <Box sx={{ width: '350px', display: 'flex', flexDirection: 'column', gap: 2 }}>
                <TextField
                    fullWidth
                    autoComplete="username"
                    type="email"
                    label="Email Address"
                />
                <TextField
                    fullWidth
                    autoComplete="current-password"
                    type={showPassword ? "text" : "password"}
                    label="Password"
                    InputProps={{
                        endAdornment: (
                            <InputAdornment position="end">
                                <IconButton
                                    onClick={() => setShowPassword((prev) => !prev)}
                                >
                                    {showPassword ? (
                                        <RemoveRedEyeIcon />
                                    ) : (
                                        <VisibilityOffIcon />
                                    )}
                                </IconButton>
                            </InputAdornment>
                        ),
                    }}
                />
                <Stack
                    direction="row"
                    alignItems="center"
                    justifyContent="space-between"
                >
                    <FormControlLabel
                        control={
                            <Checkbox
                                checked={true}
                            />
                        }
                        label="Remember me"
                    />
                    <Link href="#" underline="hover">
                        Forgot password?
                    </Link>
                </Stack>
                <Button fullWidth variant="contained">LogIn</Button>
            </Box>
        </Box>
    );
};

export default Login;
