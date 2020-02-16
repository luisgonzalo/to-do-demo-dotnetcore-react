import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import { Container, Grid, Paper, List, Divider, ListSubheader, IconButton, TextField } from '@material-ui/core';
import { TodoItem } from '../model/todoItem';
import AddIcon from '@material-ui/icons/Add';
import { TodoListItem } from './TodoListItem';
import { todoListApi } from '../api/todoListApi';
import { toast } from 'react-toastify';

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
  const [items, setItems] = useState<TodoItem[]>([]);
  const [itemDescription, setItemDescription] = useState<string>("");
  const [isLoaded, setIsLoaded] = useState<boolean>();
  
  useEffect(
    () => {
      if (isLoaded === undefined) {
        setIsLoaded(false);
        todoListApi.getTodoItems()
          .then(
            (result) => {
              setIsLoaded(true);
              setItems(result);
            },
            (error) => {
              toast.error(error.message);
            }
          );
      }
    },
    [isLoaded]
  );

  const pendingTodoItems = items.filter(item => !item.isComplete);
  const completedItems = items.filter(item => item.isComplete);

  const handleItemDescriptionChange = (value: string) => {
    setItemDescription(value);
  };

  const handleAddTask = () => {
    todoListApi.addTodoItem({ id: items.length + 1, description: itemDescription, isComplete: false })
      .then(
        () => {
          setItemDescription('');
          setIsLoaded(undefined);
        },
        (error) => {
          toast.error(error.message);
        }
      );
    
  };

  const handleCheckedChange = (item: TodoItem) => {
    item.isComplete = !item.isComplete;
    todoListApi.changeItemStatus(item)
      .then(
        () => {
          setIsLoaded(undefined);
        },
        (error) => {
          toast.error(error.message);
        }
      );
  };

  const handleKeyUp = (event: any) => {
    if (event.keyCode === 13 && itemDescription !== '') {
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
                onChange={(e) => handleItemDescriptionChange(e.target.value)}
                value={itemDescription} 
                variant="outlined"
                fullWidth
                onKeyUp={handleKeyUp}
              />
              <IconButton aria-label="add task" title="Add task" onClick={handleAddTask} disabled={itemDescription === ''} >
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
