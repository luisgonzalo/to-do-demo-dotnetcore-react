import React, { useState } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Container, Grid, Paper, List, Divider, ListSubheader, IconButton, TextField } from '@material-ui/core';
import { todoItem } from '../model/todoItem';
import AddIcon from '@material-ui/icons/Add';
import { TodoListItem } from './TodoListItem';

const useStyles = makeStyles(theme => ({
  appBarSpacer: theme.mixins.toolbar,
  content: {
    flexGrow: 1,
    height: '100vh',
    overflow: 'auto',
  },
  container: {
    paddingTop: theme.spacing(4),
    paddingBottom: theme.spacing(4),
  },
  paper: {
    padding: theme.spacing(2),
    margin: theme.spacing(2),
    display: 'flex',
    overflow: 'auto',
    flexDirection: 'row',
  },
  fixedHeight: {
    height: 240,
  },
}));

export const ToDoList = () => {
  const classes = useStyles();
  const [items, setItems] = useState<todoItem[]>([]);
  const [taskDescription, setTaskDescription] = useState<string>("");
  
  const pendingTodoItems = items.filter(item => !item.isComplete);
  const completedItems = items.filter(item => item.isComplete);

  const handleTaskChange = (value: string) => {
    setTaskDescription(value);
  };

  const handleAddTask = () => {
    setItems([...items, { id: items.length + 1, description: taskDescription, isComplete: false }]);
    setTaskDescription('');
  };

  const handleCheckedChange = (item: todoItem) => {
    item.isComplete = !item.isComplete;
    setItems([...items]);
  };

  const handleKeyUp = (event: any) => {
    if (event.keyCode === 13 && taskDescription !== '') {
      handleAddTask();
    }
  };

  return (
    <main className={classes.content}>
      <div className={classes.appBarSpacer} />
      <Container maxWidth="lg" className={classes.container}>
        <Grid container spacing={3}>
          <Grid item xs={12}>
            <Paper className={classes.paper}>
              <TextField
                required
                id="outlined-required"
                label="Add Task"
                onChange={(e) => handleTaskChange(e.target.value)}
                value={taskDescription} 
                variant="outlined"
                fullWidth
                onKeyUp={handleKeyUp}
              />
              <IconButton aria-label="add task" title="Add task" onClick={handleAddTask} disabled={taskDescription === ''} >
                <AddIcon />
              </IconButton>
            </Paper>
            <Paper className={classes.paper}>
              <List component="nav" aria-label="tasks">
                <ListSubheader inset>Pending tasks</ListSubheader>
                {
                  pendingTodoItems.map((item, index) => (
                    <TodoListItem key={index} item={item} onCheckedChange={handleCheckedChange} />
                  ))
                }
                <Divider />
                <ListSubheader inset>Completed tasks</ListSubheader>
                {
                  completedItems.map((item, index) => (
                    <TodoListItem key={index} item={item} onCheckedChange={handleCheckedChange} />
                  ))
                }
              </List>
            </Paper>
          </Grid>
        </Grid>
      </Container>
    </main>
  );
}
